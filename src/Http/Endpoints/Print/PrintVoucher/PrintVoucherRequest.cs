namespace SpeedyNET.Http.Endpoints.Print.PrintVoucher;


internal record PrintVoucherRequest(
	string UserName,
	string Password,
	string[] ShipmentIds,
	string? Language,
	long? ClientSystemId,
	string? PrinterName,
	PaperFormat? Format,
	Dpi? Dpi
);
