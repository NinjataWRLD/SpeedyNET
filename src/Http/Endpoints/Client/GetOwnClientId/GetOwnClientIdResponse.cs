namespace SpeedyNET.Http.Endpoints.Client.GetOwnClientId;

internal record GetOwnClientIdResponse(
	long ClientId,
	ErrorDto? Error
);
