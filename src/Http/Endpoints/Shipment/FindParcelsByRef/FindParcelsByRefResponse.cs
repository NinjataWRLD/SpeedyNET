namespace SpeedyNET.Http.Endpoints.Shipment.FindParcelsByRef;

internal record FindParcelsByRefResponse(
	string[] Barcodes,
	ErrorDto? Error
);
