using Refit;

namespace SpeedyNET.Http.Endpoints.Pickup;

using Pickup;
using PickupTerms;

internal interface IPickupEndpoints
{
	[Post("/")]
	Task<PickupResponse> Pickup(PickupRequest request, CancellationToken ct = default);

	[Post("/")]
	Task<PickupTermsResponse> PickupTerms(PickupTermsRequest request, CancellationToken ct = default);
}
