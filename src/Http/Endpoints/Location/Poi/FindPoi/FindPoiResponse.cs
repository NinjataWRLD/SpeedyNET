namespace SpeedyNET.Http.Endpoints.Location.Poi.FindPoi;

using Dtos.PointOfInterest;

internal record FindPoiResponse(
	PointOfInterestDto[]? Pois,
	ErrorDto? Error
);
