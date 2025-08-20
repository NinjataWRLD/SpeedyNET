using Refit;

namespace SpeedyNET.Http.Endpoints.Payment;

using Payout;

internal interface IPaymentEndpoints
{
	[Post("/")]
	Task<PayoutResponse> Payout(PayoutRequest request, CancellationToken ct = default);
}
