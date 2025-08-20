using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Cod;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.DeclaredValue;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Obpd;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return;

namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices;

public record ShipmentAdditionalServicesModel(
	ShipmentCodAdditionalServiceModel? Cod,
	ShipmentObpdModel? Obdp,
	ShipmentDeclaredValueAdditionalServiceModel? DeclaredValue,
	ShipmentReturnAdditionalServicesModel? Returns,
	int? FixedTimeDelivery,
	int? SpecialDeliveryId,
	int? DeliveryToFloor
);
