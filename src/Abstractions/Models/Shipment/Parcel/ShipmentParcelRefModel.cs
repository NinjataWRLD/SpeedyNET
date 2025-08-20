namespace SpeedyNET.Abstractions.Models.Shipment.Parcel;

public record ShipmentParcelRefModel(
	string? Id,
	string? ExternalCarrierParcelNumber,
	string? FullBarcode
);
