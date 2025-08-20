namespace SpeedyNET.Http.Endpoints.Location.State.GetState;

using Dtos.State;

internal record GetStateResponse(
	StateDto? State,
	ErrorDto? Error
);
