namespace SpeedyNET.Http.Endpoints.Shipment.ShipmentInfo;

using Dtos.Shipment;

internal record ShipmentInfoResponse(
	ShipmentDto[] Shipments,
	ErrorDto? Error
);
