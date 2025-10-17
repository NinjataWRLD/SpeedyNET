﻿using SpeedyNET.Http.Endpoints.Calculation;
using SpeedyNET.Abstractions.Contracts.Location;
using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Abstractions.Contracts.Calculation;
using SpeedyNET.Abstractions.Contracts.Client;
using SpeedyNET.Http.Endpoints.Calculation.Calculation;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Calculation;

internal class CalculationService(
	ICalculationEndpoints endpoints,
	IClientService clientService,
	ILocationService locationService,
	IServicesService servicesService
) : ICalculationService
{
	public async Task<CalculateModel[]> CalculateAsync(
		SpeedyAccount account,
		SpeedyPickup pickup,
		Payer payer,
		double[] weights,
		string country,
		string site,
		string street,
		CancellationToken ct = default
	)
	{
		int dropoffCountryId = await locationService.GetCountryId(account, country, ct).ConfigureAwait(false);
		int pickupCountryId = await locationService.GetCountryId(account, pickup.Country, ct).ConfigureAwait(false);

		long dropoffSiteId = await locationService.GetSiteId(account, dropoffCountryId, site, ct).ConfigureAwait(false);
		long pickupSiteId = await locationService.GetSiteId(account, pickupCountryId, pickup.City, ct).ConfigureAwait(false);

		street.Discombobulate(out string dropoffStreetName, out string _);
		pickup.Street.Discombobulate(out string pickupStreetName, out string _);

		long dropoffStreetId = await locationService.GetStreetId(account, dropoffSiteId, dropoffStreetName, ct).ConfigureAwait(false);
		long pickupStreetId = await locationService.GetStreetId(account, pickupSiteId, pickupStreetName, ct).ConfigureAwait(false);

		var dropoffOffice = await locationService.GetOfficeId(account, dropoffCountryId, dropoffSiteId, dropoffStreetId, ct).ConfigureAwait(false);
		var pickupOffice = await locationService.GetOfficeId(account, pickupCountryId, pickupSiteId, pickupStreetId, ct).ConfigureAwait(false);

		long clientId = await clientService.GetOwnClientIdAsync(account, ct).ConfigureAwait(false);
		var services = await servicesService.Services(account, null, ct).ConfigureAwait(false);

		CalculationRequest request = new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Sender: new(
				ClientId: clientId,
				DropoffOfficeId: dropoffOffice.OfficeId,
				DropoffGeoPUDOId: null,
				AddressLocation: null,
				PrivatePerson: null
			),
			Recipient: new(
				ClientId: clientId,
				PickupOfficeId: pickupOffice.OfficeId,
				PrivatePerson: null,
				AddressLocation: null,
				PickupGeoPUDOId: null
			),
			Service: new(
				ServiceIds: [.. services.Select(s => s.Id)],
				PickupDate: null,
				AutoAdjustPickupDate: true,
				AdditionalServices: null,
				SaturdayDelivery: null,
				DeferredDays: null
			),
			Content: new(
				ParcelsCount: null,
				TotalWeight: null,
				Parcels: [.. weights.Select(weight => weight.ToParcelDto())],
				Palletized: null,
				Documents: null
			),
			Payment: new(
				CourierServicePayer: payer,
				DeclaredValuePayer: null,
				PackagePayer: null,
				ThirdPartyClientId: null,
				DiscountCardId: null,
				SenderBankAccount: null,
				AdministrativeFee: null
			)
		);
		var response = await endpoints.Calculation(request, ct).ConfigureAwait(false);

		response.Error.EnsureNull();

		var calculations = response.Calculations.ToList();
		if (!calculations.Any(c => c.Error is null))
		{
			calculations.ForEach(c => c.Error.EnsureNull());
		}

		return [.. calculations.Where(c => c.Error is null).Select(c => c.ToModel(services))];
	}
}
