namespace SpeedyNET.Http.Endpoints.Client.GetContractClients;

using Dtos.Client;

internal record GetContractClientsResponse(
	ClientDto[]? Clients,
	ErrorDto? Error
);
