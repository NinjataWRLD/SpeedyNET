namespace SpeedyNET.Abstractions.Contracts.Track;

public record TrackedParcelOperationAdditionalInfoModel(
	string? OfficeUrl,
	string? GeoPudoId,
	TrackedParcelOperationAdditionalInfoPredictModel? Predict
);
