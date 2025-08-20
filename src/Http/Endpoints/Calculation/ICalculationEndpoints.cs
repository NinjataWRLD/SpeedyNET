using Refit;

namespace SpeedyNET.Http.Endpoints.Calculation;

using Calculation;

internal interface ICalculationEndpoints
{
	[Post("/")]
	Task<CalculationResponse> Calculation(CalculationRequest request, CancellationToken ct = default);
}
