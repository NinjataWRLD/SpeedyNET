using SpeedyNET.Abstractions.Contracts.Validation;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Services;
using SpeedyNET.Abstractions.Models;
using SpeedyNET.Http.Endpoints.Validation;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Validation;

internal class ValidationService(IValidationEndpoints endpoints) : IValidationService
{
	public async Task<bool> ValidateAddress(
		SpeedyAccount account,
		ShipmentAddressModel address,
		CancellationToken ct = default
	)
	{
		ValidationResponse response = await endpoints.ValidateAddress(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Address: address.ToDto()
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Valid ?? false;
	}

	public async Task<bool> ValidatePostCode(
		SpeedyAccount account,
		string postCode,
		long? siteId = null,
		CancellationToken ct = default
	)
	{
		ValidationResponse response = await endpoints.ValidatePostCode(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			PostCode: postCode,
			SiteId: siteId,
			CountryId: null
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Valid ?? false;
	}

	public async Task<bool> ValidatePhone(
		SpeedyAccount account,
		PhoneNumberModel phoneNumber,
		CancellationToken ct = default
	)
	{
		ValidationResponse response = await endpoints.ValidatePhone(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Number: phoneNumber.Number,
			Ext: phoneNumber.Extension
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Valid ?? false;
	}

	public async Task<bool> ValidateShipment(
		SpeedyAccount account,
		WriteShipmentModel shipment,
		CancellationToken ct = default
	)
	{
		ValidationResponse response = await endpoints.ValidateShipment(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Recipient: shipment.Recipient.ToDto(),
			Service: shipment.Service.ToDto(),
			Content: shipment.Content.ToDto(),
			Payment: shipment.Payment.ToDto(),
			Sender: shipment.Sender?.ToDto(),
			Id: shipment.Id,
			ShipmentNote: shipment.ShipmentNote,
			Ref1: shipment.Ref1,
			Ref2: shipment.Ref2,
			ConsolidationRef: shipment.ConsolidationRef,
			RequireUnsuccessfulDeliveryStickerImage: shipment.RequireUnsuccessfulDeliveryStickerImage
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Valid ?? false;
	}
}
