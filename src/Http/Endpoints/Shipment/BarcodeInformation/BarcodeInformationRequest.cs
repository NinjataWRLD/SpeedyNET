namespace SpeedyNET.Http.Endpoints.Shipment.BarcodeInformation;

using Dtos.ShipmentParcels;

internal record BarcodeInformationRequest(
	string UserName,
	string Password,
	ShipmentParcelRefDto Parcel,
	string? Language,
	long? ClientSystemId
);
