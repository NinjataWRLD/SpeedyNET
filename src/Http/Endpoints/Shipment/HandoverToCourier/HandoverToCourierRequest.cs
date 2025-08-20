namespace SpeedyNET.Http.Endpoints.Shipment.HandoverToCourier;

using Dtos.ShipmentParcels;

internal record HandoverToCourierRequest(
	string UserName,
	string Password,
	ParcelHandoverDto[] Parcels,
	string? Language,
	long? ClientSystemId
);
