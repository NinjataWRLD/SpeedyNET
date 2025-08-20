namespace SpeedyNET.Http.Endpoints.Client.GetContactByExternalId;

internal record GetContactByExternalIdRequest(
	string UserName,
	string Password,
	string? Langauge,
	long? ClientSystemId,
	string? SecretKey
);
