namespace SpeedyNET.Http.Endpoints.Location.State.GetAllStates;

internal record GetAllStatesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
