namespace SpeedyNET.Http.Endpoints.Location.Site.FindSite;

using Dtos.Site;

internal record FindSiteResponse(
	SiteDto[]? Sites,
	ErrorDto? Error
);
