using SpeedyNET.Abstractions.Models;

namespace SpeedyNET.Abstractions.Contracts.Location;

public record FindNeaerestOfficeModel(
	ShipmentAddressModel Address,
	int? Distance,
	int? Limit,
	OfficeType? OfficeType,
	OfficeFeature[]? OfficeFeatures
);
