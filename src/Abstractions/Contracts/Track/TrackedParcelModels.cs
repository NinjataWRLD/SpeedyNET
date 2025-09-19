namespace SpeedyNET.Abstractions.Contracts.Track;

public record TrackedParcelModel(
	string ParcelId,
	string[]? ExternalCarrierParcelNumbers,
	Dictionary<string, ExternalCarrierParcelNumberDetailsModel>? ExternalCarrierParcelNumbersDetails,
	TrackedParcelOperationModel[] Operations
);

public record ExternalCarrierParcelNumberDetailsModel(
	int ExternalCarrierId,
	string ExternalCarrierName,
	string? TrackAndTraceUrl
);

public record TrackedParcelOperationModel(
	DateTimeOffset DateTime,
	string Operation,
	bool IsDelivered,
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

public record TrackedParcelOperationAdditionalInfoModel(
	string? OfficeUrl,
	string? GeoPudoId,
	TrackedParcelOperationAdditionalInfoPredictModel? Predict
);

public record TrackedParcelOperationAdditionalInfoPredictModel(
	DateTime PredictedVisitDateTimeFrom,
	DateTime PredictedVisitDateTimeTo,
	bool Canceled,
	int? IncludedDelayInMinutes
);
