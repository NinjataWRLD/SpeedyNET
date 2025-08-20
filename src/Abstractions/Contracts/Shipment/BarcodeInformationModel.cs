using SpeedyNET.Abstractions.Models.Shipment.Primary;

namespace SpeedyNET.Abstractions.Contracts.Shipment;

public record BarcodeInformationModel(
	LabelInfoModel LabelInfo,
	PrimaryShipmentModel PrimaryShipment,
	string PrimaryParcelId,
	string ReturnShipmentId,
	string ReturnParcelId,
	string RedirectShipmentId,
	string RedirectParcelId,
	string InitialShipmentId,
	string InitialParcelId
);
