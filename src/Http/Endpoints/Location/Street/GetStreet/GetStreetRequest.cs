namespace SpeedyNET.Http.Endpoints.Location.Street.GetStreet;

internal record GetStreetRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
