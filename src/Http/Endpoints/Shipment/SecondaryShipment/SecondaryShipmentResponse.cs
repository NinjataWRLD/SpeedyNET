namespace SpeedyNET.Http.Endpoints.Shipment.SecondaryShipment;

using Dtos.Shipment.Secondary;

internal record SecondaryShipmentResponse(
	SecondaryShipmentDto[] Shipments,
	ErrorDto? Error
);
