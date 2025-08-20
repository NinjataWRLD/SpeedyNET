namespace SpeedyNET.Http.Endpoints.Location.Country.FindCountry;

internal record FindCountryRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId,
	string? Name,
	string? IsoAlpha2,
	string? IsoAlpha3
);
