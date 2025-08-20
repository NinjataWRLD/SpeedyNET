namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Obpd;

public record ShipmentObpdModel(
	ObpdOption Option,
	int ReturnShipmentServiceId,
	Payer ReturnShipmentPayer
);
