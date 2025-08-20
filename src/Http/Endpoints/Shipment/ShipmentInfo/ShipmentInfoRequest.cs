namespace SpeedyNET.Http.Endpoints.Shipment.ShipmentInfo;

internal record ShipmentInfoRequest(
	string UserName,
	string Password,
	string[] ShipmentIds,
	string? Language,
	long? ClientSystemId
);
