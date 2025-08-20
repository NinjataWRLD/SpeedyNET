namespace SpeedyNET.Http.Endpoints.Location.Complex.GetComplex;

internal record GetComplexRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
