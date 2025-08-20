﻿using SpeedyNET.Http.Dtos.ParcelToPrint;
using SpeedyNET.Http.Dtos.ShipmentParcels;
using SpeedyNET.Http.Dtos.ShipmentPrice;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Abstractions.Models.Shipment.Price;

namespace SpeedyNET.Services.Shipment;

using static Constants;

internal static class Mapper
{
	internal static ParcelHandoverDto ToDto(this (DateTime DateTime, ShipmentParcelRefModel Parcel) model)
		=> new(
			Id: model.Parcel.Id,
			ExternalCarrierParcelNumber: model.Parcel.ExternalCarrierParcelNumber,
			FullBarcode: model.Parcel.FullBarcode,
			DateTime: model.DateTime.ToString(DateTimeFormat)
		);

	internal static CreatedShipmentParcelModel ToModel(this CreatedShipmentParcelDto dto)
		=> new(
			SeqNo: dto.SeqNo,
			Id: dto.Id,
			ExternalCarrierId: dto.ExternalCarrierId,
			ExternalCarrierParcelNumber: dto.ExternalCarrierParcelNumber
		);

	internal static ShipmentPriceModel ToModel(this ShipmentPriceDto dto)
		=> new(
			Amount: dto.Amount,
			Vat: dto.Vat,
			Total: dto.Total,
			Currency: dto.Currency,
			Details: dto.Details.ToDictionary(kv => kv.Key, kv => kv.Value.ToModel()),
			AmountLocal: dto.AmountLocal,
			VatLocal: dto.VatLocal,
			TotalLocal: dto.TotalLocal,
			CurrencyLocal: dto.CurrencyLocal,
			DetailsLocal: dto.DetailsLocal.ToDictionary(kv => kv.Key, kv => kv.Value.ToModel()),
			CurrencyExchangeRateUnit: dto.CurrencyExchangeRateUnit,
			CurrencyExchangeRate: dto.CurrencyExchangeRate,
			ReturnAmounts: dto.ReturnAmounts?.ToModel()
		);

	internal static ShipmentPriceAmountModel ToModel(this ShipmentPriceAmountDto dto)
		=> new(
			Amount: dto.Amount,
			VatPercent: dto.VatPercent,
			Percent: dto.Percent
		);

	internal static ReturnAmountsModel ToModel(this ReturnAmountsDto dto)
		=> new(
			MoneyTransfer: dto.MoneyTransfer?.ToModel()
		);

	internal static MoneyTransferPremiumModel ToModel(this MoneyTransferPremiumDto dto)
		=> new(
			Amount: dto.Amount,
			AmountLocal: dto.AmountLocal,
			Payer: dto.Payer
		);

	internal static LabelInfoModel ToModel(this LabelInfoDto dto)
		=> new(
			ParcelId: dto.ParcelId,
			FullBarcode: dto.FullBarcode,
			ExportPriority: dto.ExportPriority,
			HubId: dto.HubId,
			OfficeId: dto.OfficeId,
			OfficeName: dto.OfficeName,
			DeadlineDay: dto.DeadlineDay,
			DeadlineMonth: dto.DeadlineMonth,
			TourId: dto.TourId
		);
}
