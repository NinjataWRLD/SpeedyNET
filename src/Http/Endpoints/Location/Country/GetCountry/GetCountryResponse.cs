namespace SpeedyNET.Http.Endpoints.Location.Country.GetCountry;

using Dtos.Country;

internal record GetCountryResponse(
	CountryDto? Country,
	ErrorDto? Error
);
