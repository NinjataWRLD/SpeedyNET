namespace SpeedyNET.Http.Endpoints.Calculation.Calculation;

using Dtos.CalculationResult;

internal record CalculationResponse(
	CalculationResultDto[] Calculations,
	ErrorDto? Error
);
