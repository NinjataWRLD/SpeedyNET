using SpeedyNET.Abstractions.Models.Shipment.Price;

namespace SpeedyNET.Abstractions.Contracts.Shipment;

public record WrittenShipmentModel(
	string Id,
	CreatedShipmentParcelModel[] Parcels,
	ShipmentPriceModel Price,
	DateOnly PickupDate,
	DateTime DeliveryDeadline
);
