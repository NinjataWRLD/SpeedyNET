namespace SpeedyNET.Http.Endpoints.Location.Block.GetAllBlocks;

internal record GetAllBlocksRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
