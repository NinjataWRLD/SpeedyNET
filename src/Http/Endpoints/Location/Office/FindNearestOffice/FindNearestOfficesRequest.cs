namespace SpeedyNET.Http.Endpoints.Location.Office.FindNearestOffice;

using Dtos.ShipmentSenderAndRecipient.ShipmentAddress;

internal record FindNearestOfficesRequest(
	string UserName,
	string Password,
	ShipmentAddressDto Address,
	string? Language,
	long? ClientSystemId,
	int? Distance,
	int? Limit,
	OfficeType? OfficeType,
	OfficeFeature[]? OfficeFeatures
);
