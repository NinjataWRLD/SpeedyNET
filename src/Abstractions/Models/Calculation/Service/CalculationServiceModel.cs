using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices;

namespace SpeedyNET.Abstractions.Models.Calculation.Service;

public record CalculationServiceModel(
	int[] ServiceIds,
	DateOnly? PickupDate,
	bool? AutoAdjustPickupDate,
	ShipmentAdditionalServicesModel? AdditionalServices,
	int? DeferredDays,
	bool? SaturdayDelivery
);
