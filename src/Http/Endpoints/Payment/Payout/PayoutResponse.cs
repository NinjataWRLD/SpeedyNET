namespace SpeedyNET.Http.Endpoints.Payment.Payout;

using Dtos.Payout;

internal record PayoutResponse(
	PayoutDto[] Payouts,
	ErrorDto? Error
);
