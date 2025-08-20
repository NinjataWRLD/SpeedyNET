namespace SpeedyNET.Http.Endpoints.Location.Site.GetAllSites;

internal record GetAllSitesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
