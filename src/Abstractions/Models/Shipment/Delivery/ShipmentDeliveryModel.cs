namespace SpeedyNET.Abstractions.Models.Shipment.Delivery;

public record ShipmentDeliveryModel(
	DateTime Deadline,
	DateTime? DeliveryDateTime,
	string? Consignee,
	string? DeliveryNote
);
