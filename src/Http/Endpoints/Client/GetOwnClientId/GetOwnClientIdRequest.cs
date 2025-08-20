namespace SpeedyNET.Http.Endpoints.Client.GetOwnClientId;

internal record GetOwnClientIdRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
