namespace SpeedyNET.Http.Endpoints.Location.Office.FindOffice;

using Dtos.Office;

internal record FindOfficeResponse(
	OfficeDto[]? Offices,
	ErrorDto? Error
);
