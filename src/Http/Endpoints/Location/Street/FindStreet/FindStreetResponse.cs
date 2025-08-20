namespace SpeedyNET.Http.Endpoints.Location.Street.FindStreet;

using Dtos.Street;

internal record FindStreetResponse(
	StreetDto[]? Streets,
	ErrorDto? Error
);
