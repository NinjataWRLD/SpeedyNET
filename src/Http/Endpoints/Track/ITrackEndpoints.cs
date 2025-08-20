using Refit;

namespace SpeedyNET.Http.Endpoints.Track;

using BulkTrackingDataFiles;
using Track;

internal interface ITrackEndpoints
{
	[Post("/")]
	Task<TrackResponse> Track(TrackRequest request, CancellationToken ct = default);

	[Post("/bulk")]
	Task<BulkTrackingDataFilesResponse> BulkTrackingDataFiles(BulkTrackingDataFilesRequest request, CancellationToken ct = default);
}
