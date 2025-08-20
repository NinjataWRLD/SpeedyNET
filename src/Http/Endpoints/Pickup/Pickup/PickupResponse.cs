namespace SpeedyNET.Http.Endpoints.Pickup.Pickup;

using Dtos.PickupOrder;

internal record PickupResponse(
	PickupOrderDto[] Orders,
	ErrorDto? Error
);
