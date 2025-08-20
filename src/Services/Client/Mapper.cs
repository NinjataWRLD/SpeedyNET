﻿using SpeedyNET.Http.Dtos.CodAdditionalServiceContractInfo;
using SpeedyNET.Http.Dtos.SpecialDeliveryRequirements;
using SpeedyNET.Abstractions.Models.Client;

namespace SpeedyNET.Services.Client;

internal static class Mapper
{

	internal static SpecialDeliveryRequirementsModel ToModel(this SpecialDeliveryRequirementsDto model)
		=> new(
			RequiredForAllShipments: model.RequiredForAllShipments,
			Requirements: [.. model.Requirements.Select(r => (r.Id, r.Text))]
		);

	internal static CodAdditionalServiceContractInfoModel ToModel(this CodAdditionalServiceContractInfoDto dto)
		=> new(
			MoneyTransferAllowed: dto.MoneyTransferAllowed,
			CodFiscalReceiptAllowed: dto.CodFiscalReceiptAllowed,
			HasCodAnnex: dto.HasCODAnnex,
			InternationalCodAnnexes: [.. dto.InternationalCODAnnexes.Select(a => (a.CountryId, a.CountryName))]
		);
}
