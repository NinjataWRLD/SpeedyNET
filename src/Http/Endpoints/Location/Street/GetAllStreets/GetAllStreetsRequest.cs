namespace SpeedyNET.Http.Endpoints.Location.Street.GetAllStreets;

internal record GetAllStreetsRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
