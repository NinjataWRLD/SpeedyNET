using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Payment;

internal interface IPaymentService
{
	Task<PayoutModel[]> Payout(SpeedyAccount account, DateTime fromDate, DateTime toDate, bool? includeDetails = null, CancellationToken ct = default);
}
