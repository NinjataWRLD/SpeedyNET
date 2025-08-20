namespace SpeedyNET.Http.Endpoints.Payment.Payout;

internal record PayoutRequest(
	string UserName,
	string Password,
	string FromDate,
	string ToDate,
	string? Language,
	long? ClientSystemId,
	bool? IncludeDetails
);
