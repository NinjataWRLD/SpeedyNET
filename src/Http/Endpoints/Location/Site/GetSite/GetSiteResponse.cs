namespace SpeedyNET.Http.Endpoints.Location.Site.GetSite;

using Dtos.Site;

internal record GetSiteResponse(
	SiteDto? Site,
	ErrorDto? Error
);
