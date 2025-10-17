using SpeedyNET.Abstractions.Contracts.Validation;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Services;
using SpeedyNET.Http.Endpoints.Validation;
using SpeedyNET.Abstractions.UserConfigs;
using SpeedyNET.Abstractions.Contracts.Location;

namespace SpeedyNET.Services.Validation;

internal class ValidationService(
	IValidationEndpoints endpoints,
	ILocationService locationService
) : IValidationService
{
	public async Task<bool> ValidateAddress(
		SpeedyAccount account,
		string country,
		string site,
		string street,
		CancellationToken ct = default
	)
	{
		DiscombobulateStreet(street, out string streetName, out string streetNumber);
		int countryId = await locationService.GetCountryId(account, country, ct);
		long siteId = await locationService.GetSiteId(account, countryId, site, ct);
		long streetId = await locationService.GetStreetId(account, siteId, streetName, ct);

		ValidationResponse response = await endpoints.ValidateAddress(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Address: new(
				CountryId: countryId,
				PostCode: null,
				SiteId: siteId,
				SiteType: null,
				SiteName: null,
				ComplexId: null,
				ComplexType: null,
				ComplexName: null,
				StreetId: streetId,
				StreetType: null,
				StreetName: null,
				StreetNo: streetNumber,
				BlockNo: null,
				EntranceNo: null,
				FloorNo: null,
				ApartmentNo: null,
				PoiId: null,
				AddressNote: null,
				X: null,
				Y: null
			)
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
		string phone,
		CancellationToken ct = default
	)
	{
		ValidationResponse response = await endpoints.ValidatePhone(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Number: phone,
			Ext: null
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

	private static void DiscombobulateStreet(string street, out string name, out string number)
	{
		string[] tokens = street.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		number = tokens[^1];
		name = string.Join(' ', tokens.Take(tokens.Length - 1));
	}
}
