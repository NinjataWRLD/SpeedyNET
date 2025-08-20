namespace SpeedyNET.Http.Endpoints.Location.Office.GetOffice;

using Dtos.Office;

internal record GetOfficeResponse(
	OfficeDto? Office,
	ErrorDto? Error
);
