namespace SpeedyNET.Abstractions.Models.Shipment.Recipient;

public record AutoSelectNearestOfficePolicyModel(
	UnavailableNearestOfficeAction UnavailableNearestOfficeAction,
	OfficeType OfficeType
);
