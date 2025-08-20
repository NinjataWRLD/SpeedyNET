﻿namespace SpeedyNET.Http.Endpoints.Pickup.Pickup;

internal record PickupRequest(
	string UserName,
	string Password,
	string VisitEndTime,
	string? Language,
	long? ClientSystemId,
	string? PickupDateTime,
	bool? AutoAdjustPickupDate,
	PickupScope? PickupScope,
	string[]? ExplicitShipmentIdList,
	string? ContactName,
	string? PhoneNumber
);
