namespace SpeedyNET.Http.Endpoints.Shipment.CancelShipment;

internal record CancelShipmentRequest(
	string UserName,
	string Password,
	string ShipmentId,
	string Comment,
	string? Language,
	long? ClientSystemId
);
