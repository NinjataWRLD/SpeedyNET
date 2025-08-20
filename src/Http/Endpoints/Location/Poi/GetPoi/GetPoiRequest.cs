namespace SpeedyNET.Http.Endpoints.Location.Poi.GetPoi;

internal record GetPoiRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
