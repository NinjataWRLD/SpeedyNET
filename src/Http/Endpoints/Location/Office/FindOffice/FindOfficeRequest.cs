namespace SpeedyNET.Http.Endpoints.Location.Office.FindOffice;

internal record FindOfficeRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId,
	int? CountryId,
	long? SiteId,
	string? SiteName,
	string? Name,
	long? Limit
);
