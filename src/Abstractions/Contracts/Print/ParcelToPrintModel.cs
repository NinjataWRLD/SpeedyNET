using SpeedyNET.Abstractions.Models.Shipment.Parcel;

namespace SpeedyNET.Abstractions.Contracts.Print;

public record ParcelToPrintModel(
	ShipmentParcelRefModel Parcel,
	ParcelToPrintAdditionalBarcodeModel? AdditionalBarcode
);
