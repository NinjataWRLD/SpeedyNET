namespace SpeedyNET.Http.Endpoints.Location.Complex.GetComplex;

using Dtos.Complex;

internal record GetComplexResponse(
	ComplexDto? Complex,
	ErrorDto? Error
);
