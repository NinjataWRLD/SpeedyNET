namespace SpeedyNET.Http.Endpoints.Print.ExtendedPrint;

using Dtos.ParcelToPrint;

internal record ExtendedPrintRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId,
	PaperFormat? Format,
	PaperSize? PaperSize,
	ParcelToPrintDto[] Parcels,
	string? PrinterName,
	Dpi? Dpi,
	AdditionalWaybillSenderCopy? AdditionalWaybillSenderCopy
);
