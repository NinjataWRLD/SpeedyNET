namespace SpeedyNET.Http.Endpoints.Shipment.CreateShipment;

using Dtos.ShipmentParcels;
using Dtos.ShipmentPrice;

internal record CreateShipmentResponse(
	string Id,
	CreatedShipmentParcelDto[] Parcels,
	ShipmentPriceDto Price,
	string PickupDate,
	string DeliveryDeadline,
	ErrorDto? Error
);
