using SpeedyNET.Abstractions.Models.Calculation.Recipient;
using SpeedyNET.Abstractions.Models.Calculation.Sender;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Services;

internal interface IServicesService
{
	Task<(string Deadline, CourierServiceModel CourierService)[]> DestinationServices(SpeedyAccount account, CalculationRecipientModel recipient, DateOnly? date = null, CalculationSenderModel? sender = null, CancellationToken ct = default);
	Task<CourierServiceModel[]> Services(SpeedyAccount account, DateOnly? date = null, CancellationToken ct = default);
}
