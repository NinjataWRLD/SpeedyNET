namespace SpeedyNET.Http.Endpoints.Location.State.GetState;

internal record GetStateRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
