namespace SpeedyNET.Abstractions.Contracts.Pickup;

public record PickupModel(
	long Id,
	string[] ShipmentIds,
	DateTime? PickupPeriodFrom,
	DateTime? PickupPeriodTo
);
