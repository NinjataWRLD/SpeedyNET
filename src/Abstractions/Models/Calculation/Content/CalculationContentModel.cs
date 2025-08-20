using SpeedyNET.Abstractions.Models.Shipment.Parcel;

namespace SpeedyNET.Abstractions.Models.Calculation.Content;

public record CalculationContentModel(
	int? ParcelsCount,
	double? TotalWeight,
	bool? Documents,
	bool? Palletized,
	ShipmentParcelModel[]? Parcels
);
