﻿namespace SpeedyNET.Abstractions.Models.Client;

public record CodAdditionalServiceContractInfoModel(
	bool MoneyTransferAllowed,
	bool CodFiscalReceiptAllowed,
	bool HasCodAnnex,
	(int CountryId, string CountryName)[] InternationalCodAnnexes
);
