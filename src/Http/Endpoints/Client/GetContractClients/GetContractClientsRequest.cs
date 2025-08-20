namespace SpeedyNET.Http.Endpoints.Client.GetContractClients;

internal record GetContractClientsRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
