namespace SpeedyNET.Http.Endpoints.Location.Block.FindBlock;

using Dtos.Block;

internal record FindBlockResponse(
	BlockDto[]? Blocks,
	ErrorDto? Error
);
