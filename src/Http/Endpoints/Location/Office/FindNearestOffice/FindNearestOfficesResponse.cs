namespace SpeedyNET.Http.Endpoints.Location.Office.FindNearestOffice;

using Dtos.SpecialDeliveryRequirements;

internal record FindNearestOfficesResponse(
	OfficeResultDto[]? Offices,
	double? X,
	double? Y,
	ErrorDto? Error
);
