namespace SpeedyNET.Http.Endpoints.Location.Complex.FindComplex;

using Dtos.Complex;

internal record FindComplexResponse(
	ComplexDto[]? Complexes,
	ErrorDto? Error
);
