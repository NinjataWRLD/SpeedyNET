namespace SpeedyNET.Http.Endpoints.Shipment.UpdateShipmentProperties;

using Dtos.ShipmentParcels;
using Dtos.ShipmentPrice;

internal record UpdateShipmentPropertiesResponse(
	// Copied from UpdateShipmentResponse
	string Id,
	CreatedShipmentParcelDto[] Parcels,
	ShipmentPriceDto Price,
	string PickupDate,
	string DeliveryDeadline,
	ErrorDto? Error
);
