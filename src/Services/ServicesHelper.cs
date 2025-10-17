﻿using SpeedyNET.Abstractions.Contracts.Location;
using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services;

internal static class ServicesHelper
{
	internal static async Task<int> GetCountryId(this ILocationService locationService, SpeedyAccount account, string name, CancellationToken ct)
	{
		CountryModel[] countries = await locationService.FindCountryAsync(
			account: account,
			name: name,
			ct: ct
		).ConfigureAwait(false);

		return countries.First().Id;
	}

	internal static async Task<long> GetSiteId(this ILocationService locationService, SpeedyAccount account, int countryId, string name, CancellationToken ct)
	{
		SiteModel[] sites = await locationService.FindSiteAsync(
			account: account,
			countryId: countryId,
			name: name,
			ct: ct
		).ConfigureAwait(false);

		return sites.First().Id;
	}

	internal static async Task<long> GetStreetId(this ILocationService locationService, SpeedyAccount account, long siteId, string name, CancellationToken ct)
	{
		StreetModel[] streets = await locationService.FindStreetAsync(
			account: account,
			siteId: Convert.ToInt32(siteId),
			name: name,
			type: null,
			ct: ct
		).ConfigureAwait(false);

		return streets.First().Id;
	}

	internal static async Task<(int Distance, int OfficeId)> GetOfficeId(this ILocationService locationService, SpeedyAccount account, int countryId, long siteId, long streetId, CancellationToken ct)
	{
		var offices = await locationService.GetOfficeAsync(
			model: new(
				Address: new(
					CountryId: countryId,
					SiteId: siteId,
					StreetId: streetId,
					ComplexId: null,
					SiteType: null,
					StreetType: null,
					ComplexType: null,
					SiteName: null,
					ComplexName: null,
					StreetName: null,
					StreetNo: null,
					BlockNo: null,
					EntranceNo: null,
					FloorNo: null,
					ApartmentNo: null,
					PoiId: null,
					AddressNote: null,
					PostCode: null,
					X: null,
					Y: null
				),
				Distance: null,
				Limit: null,
				OfficeType: null,
				OfficeFeatures: null
			),
			account: account,
			ct: ct
		).ConfigureAwait(false);

		var (Distance, Office) = offices.OrderBy(x => x.Distance).First();
		return (Distance, Office.Id);
	}

	internal static async Task<int> GetServiceId(this IServicesService servicesService, SpeedyAccount account, string service, CancellationToken ct)
	{
		CourierServiceModel[] services = await servicesService.Services(
			account: account,
			date: null,
			ct: ct
		).ConfigureAwait(false);

		return services.First(s => s.Name == service || s.NameEn == service).Id;
	}

	internal static void Discombobulate(this string street, out string name, out string number)
	{
		string[] tokens = street.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		number = tokens[^1];
		name = string.Join(' ', tokens.Take(tokens.Length - 1));
	}
}
