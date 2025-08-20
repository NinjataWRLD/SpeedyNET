using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices;

namespace SpeedyNET.Abstractions.Models.Shipment.Service;

public record ShipmentServiceModel(
	int ServiceId,
	DateOnly? PickupDate,
	ShipmentAdditionalServicesModel? AdditionalServices,
	bool? SaturdayDelivery,
	bool AutoAdjustPickupDate = false,
	int DeferredDays = 0
);
