namespace SpeedyNET.Http.Endpoints.Pickup.PickupTerms;

internal record PickupTermsResponse(
	string[] Cutoffs,
	ErrorDto? Error
);
