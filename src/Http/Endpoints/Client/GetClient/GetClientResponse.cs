namespace SpeedyNET.Http.Endpoints.Client.GetClient;

using Dtos.Client;

internal record GetClientResponse(
	ClientDto? Client,
	ErrorDto? Error
);
