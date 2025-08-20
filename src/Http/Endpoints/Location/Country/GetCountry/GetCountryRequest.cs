namespace SpeedyNET.Http.Endpoints.Location.Country.GetCountry;

internal record GetCountryRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
