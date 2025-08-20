namespace SpeedyNET.Http.Endpoints.Location.Poi.GetAllPois;

internal record GetAllPoisRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
