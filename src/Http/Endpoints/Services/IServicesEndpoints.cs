using Refit;

namespace SpeedyNET.Http.Endpoints.Services;

using DestinationServices;
using Services;

internal interface IServicesEndpoints
{
	[Post("/")]
	Task<ServicesResponse> Services(ServicesRequest request, CancellationToken ct = default);

	[Post("/destination")]
	Task<DestinationServicesResponse> DestinationServices(DestinationServicesRequest request, CancellationToken ct = default);
}
