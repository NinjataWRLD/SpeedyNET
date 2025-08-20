namespace SpeedyNET.Http.Endpoints.Print.Print;

using Dtos.ParcelToPrint;

internal record PrintRequest(
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
