namespace SpeedyNET.Http.Endpoints.Location.Site.GetSite;

internal record GetSiteRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
