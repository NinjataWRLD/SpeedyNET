namespace SpeedyNET.Http.Endpoints.Print.LabelInfo;

using Dtos.ParcelToPrint;

internal record LabelInfoResponse(
	LabelInfoDto[] PrintLabelsInfo,
	ErrorDto? Error
);
