namespace SpeedyNET.Http.Endpoints.Track.Track;

using Dtos.ShipmentParcels;

internal record TrackRequest(
	string UserName,
	string Password,
	TrackShipmentParcelRefDto[] Parcels,
	string? Language,
	long? ClientSystemId,
	bool? LastOperationOnly
);
