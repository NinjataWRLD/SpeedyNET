namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.ElectronicReceipt;

public record ShipmentElectronicReturnReceiptAdditionalServiceModel(
	string[] RecipientEmails,
	bool? ThirdPartyPayer
);
