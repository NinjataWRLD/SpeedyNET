namespace SpeedyNET.Http.Endpoints.Track.Track;

using Dtos.TrackedParcel;

internal record TrackResponse(
	TrackedParcelDto[] Parcels,
	ErrorDto? Error
);
