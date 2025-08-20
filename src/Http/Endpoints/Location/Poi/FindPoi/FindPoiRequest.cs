namespace SpeedyNET.Http.Endpoints.Location.Poi.FindPoi;

internal record FindPoiRequest(
	string UserName,
	string Password,
	int SiteId,
	string? Language,
	long? ClientSystemId,
	string? Name
);
