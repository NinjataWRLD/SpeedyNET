namespace SpeedyNET.Http.Endpoints.Client.ContractInfo;

internal record ContractInfoRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
