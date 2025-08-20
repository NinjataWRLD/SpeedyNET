namespace SpeedyNET.Abstractions.Models.Shipment.Parcel;

public record ExternalCarrierParcelNumberModel(
	Carrier ExternalCarrier,
	string ParcelNumber
);
