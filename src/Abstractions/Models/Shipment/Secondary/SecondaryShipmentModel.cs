namespace SpeedyNET.Abstractions.Models.Shipment.Secondary;

public record SecondaryShipmentModel(
	string Id,
	ShipmentType Type,
	(string Id, int SeqNo)[] Parcels,
	DateOnly PickupDate,
	int ServiceId,
	bool HasScans
);
