using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Services.Mappers.Calculation;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Calculation.Recipient;
using SpeedyNET.Abstractions.Models.Calculation.Sender;
using SpeedyNET.Http.Endpoints.Services;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Services;

using static Constants;

internal class ServicesService(IServicesEndpoints endpoints) : IServicesService
{
	public async Task<CourierServiceModel[]> Services(
		SpeedyAccount account,
		DateOnly? date = null,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.Services(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Date: date?.ToString(DateFormat)
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Services.Select(s => s.ToModel())];
	}

	public async Task<(string Deadline, CourierServiceModel CourierService)[]> DestinationServices(
		SpeedyAccount account,
		CalculationRecipientModel recipient,
		DateOnly? date = null,
		CalculationSenderModel? sender = null,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.DestinationServices(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Recipient: recipient.ToDto(),
			Date: date?.ToString(DateFormat),
			Sender: sender?.ToDto()
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Services.Select(s => s.ToModel())];
	}
}
