namespace SpeedyNET.Http.Endpoints.Client.CreateContact;

internal record CreateContactResponse(
	long ClientId,
	ErrorDto? Error
);
