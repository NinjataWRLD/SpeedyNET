namespace SpeedyNET.Http.Endpoints.Location.State.FindState;

using Dtos.State;

internal record FindStateResponse(
	StateDto[]? States,
	ErrorDto? Error
);
