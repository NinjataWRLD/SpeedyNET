namespace SpeedyNET.Http.Endpoints.Location.Office.GetOffice;

internal record GetOfficeRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
