﻿using SpeedyNET.Abstractions.Contracts.Payment;
using SpeedyNET.Core;
using SpeedyNET.Http.Endpoints.Payment;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Payment;

using static Constants;

internal class PaymentService(IPaymentEndpoints endpoints) : IPaymentService
{
	public async Task<PayoutModel[]> Payout(
		SpeedyAccount account,
		DateTime fromDate,
		DateTime toDate,
		bool? includeDetails = null,
		CancellationToken ct = default)
	{
		var response = await endpoints.Payout(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			FromDate: fromDate.ToString(DateTimeFormat),
			ToDate: toDate.ToString(DateTimeFormat),
			IncludeDetails: includeDetails
		), ct).ConfigureAwait(false);

		response.Error?.EnsureNull();
		return [.. response.Payouts.Select(p => p.ToModel())];
	}
}
