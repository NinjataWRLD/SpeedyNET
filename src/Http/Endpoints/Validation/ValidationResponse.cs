namespace SpeedyNET.Http.Endpoints.Validation;

internal record ValidationResponse(
	bool? Valid,
	ErrorDto? Error
);
