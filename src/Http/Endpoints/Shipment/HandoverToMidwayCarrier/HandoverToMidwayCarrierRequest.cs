namespace SpeedyNET.Http.Endpoints.Shipment.HandoverToMidwayCarrier;

using Dtos.ShipmentParcels;

internal record HandoverToMidwayCarrierRequest(
	string UserName,
	string Password,
	ParcelHandoverDto[] Parcels,
	string? Language,
	long? ClientSystemId
);
