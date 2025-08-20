namespace SpeedyNET.Abstractions.Models.Client;

public record SpecialDeliveryRequirementsModel(
	bool RequiredForAllShipments,
	(int Id, string Text)[] Requirements
);
