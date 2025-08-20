namespace SpeedyNET.Http.Endpoints.Shipment.SecondaryShipment;

internal record SecondaryShipmentRequest(
	string UserName,
	string Password,
	ShipmentType[] Types,
	string? Language,
	long? ClientSystemId
);
