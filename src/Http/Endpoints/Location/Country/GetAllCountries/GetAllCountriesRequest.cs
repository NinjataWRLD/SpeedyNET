namespace SpeedyNET.Http.Endpoints.Location.Country.GetAllCountries;

internal record GetAllCountriesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
