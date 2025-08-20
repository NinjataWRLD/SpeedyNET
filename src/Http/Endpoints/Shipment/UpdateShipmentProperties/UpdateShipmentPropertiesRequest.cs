namespace SpeedyNET.Http.Endpoints.Shipment.UpdateShipmentProperties;

internal record UpdateShipmentPropertiesRequest(
	string UserName,
	string Password,
	string Id,
	Dictionary<string, string> Properties,
	string? Language,
	long? ClientSystemId
);
