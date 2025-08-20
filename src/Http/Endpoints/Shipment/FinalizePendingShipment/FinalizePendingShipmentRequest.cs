namespace SpeedyNET.Http.Endpoints.Shipment.FinalizePendingShipment;

internal record FinalizePendingShipmentRequest(
	string UserName,
	string Password,
	string ShipmentId,
	string? Language,
	long? ClientSystemId
);
