namespace SpeedyNET.Http.Endpoints.Location.Site.FindSite;

internal record FindSiteRequest(
	string UserName,
	string Password,
	int CountryId,
	string? Language,
	long? ClientSystemId,
	string? Name,
	string? PostCode,
	string? Type,
	string? Municipality,
	string? Region
);
