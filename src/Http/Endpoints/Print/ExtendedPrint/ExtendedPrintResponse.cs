namespace SpeedyNET.Http.Endpoints.Print.ExtendedPrint;

using Dtos.ParcelToPrint;

internal record ExtendedPrintResponse(
	byte[] Data,
	LabelInfoDto[] PrintLabelsInfo,
	ErrorDto? Error
);
