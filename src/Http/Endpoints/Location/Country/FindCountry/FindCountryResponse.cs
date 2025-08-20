namespace SpeedyNET.Http.Endpoints.Location.Country.FindCountry;

using Dtos.Country;

internal record FindCountryResponse(
	CountryDto[]? Countries,
	ErrorDto? Error
);
