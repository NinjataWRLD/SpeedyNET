namespace SpeedyNET.Http.Endpoints.Services.Services;

internal record ServicesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId,
	string? Date
);
