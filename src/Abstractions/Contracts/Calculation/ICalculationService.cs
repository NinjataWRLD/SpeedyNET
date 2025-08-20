using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Calculation;

internal interface ICalculationService
{
	Task<CalculateModel[]> CalculateAsync(
		SpeedyAccount account,
		SpeedyPickup pickup,
		Payer payer,
		double[] weights,
		string country,
		string site,
		string street,
		CancellationToken ct = default
	);
}
