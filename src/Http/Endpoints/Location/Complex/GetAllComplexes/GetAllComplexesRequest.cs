namespace SpeedyNET.Http.Endpoints.Location.Complex.GetAllComplexes;

internal record GetAllComplexesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
