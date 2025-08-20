namespace SpeedyNET.Http.Endpoints.Location.Block.FindBlock;

internal record FindBlockRequest(
	string UserName,
	string Password,
	int SiteId,
	string? Language,
	long? ClientSystemId,
	string? Name,
	string? Type
);
