namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rop;

public record ShipmentRopAdditionalServiceModel(
	(int ServiceId, int ParcelsCount)[] Pallets,
	bool? ThirdPartyPayer
);
