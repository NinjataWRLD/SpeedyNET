namespace SpeedyNET.Http.Endpoints.Client.GetClient;

internal record GetClientRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
