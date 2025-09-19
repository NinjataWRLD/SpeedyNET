using SpeedyNET.Abstractions.Contracts.Track;
using SpeedyNET.Core;
using SpeedyNET.Http.Dtos.TrackedParcel;
using SpeedyNET.Http.Dtos.TrackedParcel.ExternalCarrierParcelNumberDetails;
using SpeedyNET.Http.Dtos.TrackedParcel.TrackedParcelOperation;

namespace SpeedyNET.Services.Track;

internal static class Mapper
{
	internal static TrackedParcelModel ToModel(this TrackedParcelDto dto)
		=> new(
			ParcelId: dto.ParcelId,
			ExternalCarrierParcelNumbers: dto.ExternalCarrierParcelNumbers,
			ExternalCarrierParcelNumbersDetails: dto.ExternalCarrierParcelNumbersDetails?.ToDictionary(
				x => x.Key,
				x => x.Value.ToModel()
			),
			Operations: [.. dto.Operations.Select(x => x.ToModel())]
		);

	internal static ExternalCarrierParcelNumberDetailsModel ToModel(this ExternalCarrierParcelNumberDetailsDto dto)
		=> new(
			ExternalCarrierId: dto.ExternalCarrierId,
			ExternalCarrierName: dto.ExternalCarrierName,
			TrackAndTraceUrl: dto.TrackAndTraceUrl
		);

	internal static TrackedParcelOperationModel ToModel(this TrackedParcelOperationDto dto)
		=> new(
			DateTime: dto.DateTime.ParseDateTime(),
			Operation: dto.TranslateOperation(),
			IsDelivered: dto.OperationCode is TrackCodeTranslator.DeliveredCode,
			Description: dto.Description,
			Place: dto.Place,
			Comment: dto.Comment,
			ExceptionCodes: dto.ExceptionCodes,
			ReturnShipmentId: dto.ReturnShipmentId,
			RedirectShipmentId: dto.RedirectShipmentId,
			Consignee: dto.Consignee,
			PodImageURL: dto.PodImageURL,
			AdditionalInfo: dto.AdditionalInfo?.ToModel()
		);

	internal static TrackedParcelOperationAdditionalInfoModel ToModel(this TrackedParcelOperationAdditionalInfoDto dto)
		=> new(
			OfficeUrl: dto.OfficeURL,
			GeoPudoId: dto.GeoPUDOId,
			Predict: dto.Predict?.ToModel()
		);

	internal static TrackedParcelOperationAdditionalInfoPredictModel ToModel(this TrackedParcelOperationAdditionalInfoPredictDto dto)
		=> new(
			PredictedVisitDateTimeFrom: DateTime.Parse(dto.PredictedVisitDateTimeFrom),
			PredictedVisitDateTimeTo: DateTime.Parse(dto.PredictedVisitDateTimeTo),
			Canceled: dto.Canceled,
			IncludedDelayInMinutes: dto.IncludedDelayInMinutes
		);
}
