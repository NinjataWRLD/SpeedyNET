namespace SpeedyNET.Http.Endpoints.Shipment.UpdateShipment;

using Dtos.ShipmentParcels;
using Dtos.ShipmentPrice;

internal record UpdateShipmentResponse(
	// Copied from CreateShipmentResponse
	string Id,
	CreatedShipmentParcelDto[] Parcels,
	ShipmentPriceDto Price,
	string PickupDate,
	string DeliveryDeadline,
	ErrorDto? Error
);
