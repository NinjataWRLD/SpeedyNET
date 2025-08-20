namespace SpeedyNET.Http.Endpoints.Track.BulkTrackingDataFiles;

using Dtos.BulkTrackingDataFile;

internal record BulkTrackingDataFilesResponse(
	BulkTrackingDataFileDto[] Parcels,
	ErrorDto? Error
);
