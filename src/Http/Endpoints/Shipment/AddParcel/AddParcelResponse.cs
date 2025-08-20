namespace SpeedyNET.Http.Endpoints.Shipment.AddParcel;

using Dtos.ShipmentParcels;

internal record AddParcelResponse(
	CreatedShipmentParcelDto Parcel,
	ErrorDto? Error
);
