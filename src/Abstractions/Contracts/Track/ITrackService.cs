using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Track;

internal interface ITrackService
{
	Task<(long Id, string Url)[]> BulkTrackingDataFiles(
		SpeedyAccount account,
		long? lastProcessedFileId = null,
		CancellationToken ct = default
	);

	Task<Dictionary<string, ICollection<TrackedParcelModel>>> TrackAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string[] shipmentIds,
		bool? lastOperationOnly = null,
		CancellationToken ct = default
	);
}
