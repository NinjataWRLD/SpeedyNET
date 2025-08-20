namespace SpeedyNET.Http.Endpoints.Client.GetContactByExternalId;

using Dtos.Client;

internal record GetContactByExternalIdResponse(
	ClientDto? Client,
	ErrorDto? Error
);
