﻿namespace SpeedyNET.Abstractions.Contracts.Track;

public record TrackedParcelOperationModel(
	DateTimeOffset DateTime,
	int OperationCode,
	string Description,
	string? Place,
	string? Comment,
	string[] ExceptionCodes,
	string? ReturnShipmentId,
	string? RedirectShipmentId,
	string? Consignee,
	string? PodImageURL,
	TrackedParcelOperationAdditionalInfoModel? AdditionalInfo
);
