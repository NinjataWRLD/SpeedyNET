namespace SpeedyNET.Http.Endpoints.Track.BulkTrackingDataFiles;

internal record BulkTrackingDataFilesRequest(
	string UserName,
	string Password,
	long? LastProcessedFileId,
	string? Language,
	long? ClientSystemId
);
