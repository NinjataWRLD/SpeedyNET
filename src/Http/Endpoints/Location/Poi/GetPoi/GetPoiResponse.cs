namespace SpeedyNET.Http.Endpoints.Location.Poi.GetPoi;

using Dtos.PointOfInterest;

internal record GetPoiResponse(
	PointOfInterestDto? Poi,
	ErrorDto? Error
);
