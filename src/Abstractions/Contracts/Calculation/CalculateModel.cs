using SpeedyNET.Abstractions.Models.Shipment.Price;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices;

namespace SpeedyNET.Abstractions.Contracts.Calculation;

public record CalculateModel(
	string Service,
	ShipmentAdditionalServicesModel? AdditionalServices,
	ShipmentPriceModel Price,
	DateOnly PickupDate,
	DateTimeOffset DeliveryDeadline
);
