﻿namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Cod;

public record ShipmentCodFiscalReceiptItemModel(
	string Description,
	string VatGroup,
	double Amount,
	double AmountWithVat
);
