namespace SpeedyNET.Http.Endpoints.Location.Street.GetStreet;

using Dtos.Street;

internal record GetStreetResponse(
	StreetDto? Street,
	ErrorDto? Error
);
