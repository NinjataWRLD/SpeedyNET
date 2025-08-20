using SpeedyNET.Abstractions.Models.Shipment;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices;
using SpeedyNET.Services;
using SpeedyNET.Services.Shipment;
using SpeedyNET.Http.Dtos.Shipment;
using SpeedyNET.Http.Dtos.Shipment.Delivery;
using SpeedyNET.Http.Dtos.Shipment.Primary;
using SpeedyNET.Http.Dtos.Shipment.Secondary;
using SpeedyNET.Http.Dtos.ShipmentContent;
using SpeedyNET.Http.Dtos.ShipmentContent.ShipmentParcel;
using SpeedyNET.Http.Dtos.ShipmentParcels;
using SpeedyNET.Http.Dtos.ShipmentPayment;
using SpeedyNET.Http.Dtos.ShipmentSenderAndRecipient.AutoSelectNearestOfficePolicy;
using SpeedyNET.Http.Dtos.ShipmentSenderAndRecipient.ShipmentRecipient;
using SpeedyNET.Http.Dtos.ShipmentSenderAndRecipient.ShipmentSender;
using SpeedyNET.Http.Dtos.ShipmentService;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices.ShipmentCodAdditionalService;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices.ShipmentDeclaredValueAdditionalService;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices.ShipmentObpd;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices.ShipmentReturnAdditionalServices;
using SpeedyNET.Http.Dtos.ShipmentService.ShipmentAdditionalServices.ShipmentReturnAdditionalServices.ShipmentRopAdditionalService;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Shipment.Content;
using SpeedyNET.Abstractions.Models.Shipment.Delivery;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Abstractions.Models.Shipment.Payment;
using SpeedyNET.Abstractions.Models.Shipment.Primary;
using SpeedyNET.Abstractions.Models.Shipment.Recipient;
using SpeedyNET.Abstractions.Models.Shipment.Secondary;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Cod;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.DeclaredValue;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Obpd;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.ElectronicReceipt;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Receipt;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rod;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rop;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Swap;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Voucher;
using SpeedyNET.Abstractions.Models.Shipment.Service;
using SpeedyNET.Abstractions.Models.Shipment.Sender;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return;

namespace SpeedyNET.Services.Mappers.Shipment;

using static Constants;

internal static class Mapper
{
	internal static ShipmentCodAdditionalServiceDto ToDto(this ShipmentCodAdditionalServiceModel model)
		=> new(
			Amount: model.Amount,
			CurrencyCode: model.CurrencyCode,
			PayoutToThirdParty: model.PayoutToThirdParty,
			PayoutToLoggedClient: model.PayoutToLoggedClient,
			IncludeShippingPrice: model.IncludeShippingPrice,
			CardPaymentForbidden: model.CardPaymentForbidden,
			ProcessingType: model.ProcessingType,
			FiscalReceiptItems: [.. model.FiscalReceiptItems?.Select(i => i.ToDto()) ?? []]
		);

	internal static ShipmentCodFiscalReceiptItemDto ToDto(this ShipmentCodFiscalReceiptItemModel model)
		=> new(
			Description: model.Description,
			VatGroup: model.VatGroup,
			Amount: model.Amount,
			AmountWithVat: model.AmountWithVat
		);

	internal static ShipmentCodAdditionalServiceModel ToModel(this ShipmentCodAdditionalServiceDto dto)
		=> new(
			Amount: dto.Amount,
			CurrencyCode: dto.CurrencyCode,
			PayoutToThirdParty: dto.PayoutToThirdParty,
			PayoutToLoggedClient: dto.PayoutToLoggedClient,
			IncludeShippingPrice: dto.IncludeShippingPrice,
			CardPaymentForbidden: dto.CardPaymentForbidden,
			ProcessingType: dto.ProcessingType,
			FiscalReceiptItems: [.. dto.FiscalReceiptItems?.Select(i => i.ToModel()) ?? []]
		);

	internal static ShipmentCodFiscalReceiptItemModel ToModel(this ShipmentCodFiscalReceiptItemDto dto)
		=> new(
			Description: dto.Description,
			VatGroup: dto.VatGroup,
			Amount: dto.Amount,
			AmountWithVat: dto.AmountWithVat
		);


	internal static ShipmentDeclaredValueAdditionalServiceDto ToDto(this ShipmentDeclaredValueAdditionalServiceModel model)
		=> new(
			Amount: model.Amount,
			Fragile: model.Fragile,
			IgnoreIfNotApplicable: model.IgnoreIfNotApplicable
		);

	internal static ShipmentDeclaredValueAdditionalServiceModel ToModel(this ShipmentDeclaredValueAdditionalServiceDto dto)
		=> new(
			Amount: dto.Amount,
			Fragile: dto.Fragile,
			IgnoreIfNotApplicable: dto.IgnoreIfNotApplicable
		);

	internal static ShipmentObpdDto ToDto(this ShipmentObpdModel model)
		=> new(
			Option: model.Option,
			ReturnShipmentServiceId: model.ReturnShipmentServiceId,
			ReturnShipmentPayer: model.ReturnShipmentPayer
		);

	internal static ShipmentObpdModel ToModel(this ShipmentObpdDto dto)
		=> new(
			Option: dto.Option,
			ReturnShipmentServiceId: dto.ReturnShipmentServiceId,
			ReturnShipmentPayer: dto.ReturnShipmentPayer
		);

	internal static ShipmentReturnAdditionalServicesDto ToDto(this ShipmentReturnAdditionalServicesModel model)
		=> new(
			SendBackClientId: model.SendBackClientId,
			Rod: model.Rod?.ToDto(),
			ReturnReceipt: model.ReturnReceipt?.ToDto(),
			ElectronicReturnReceipt: model.ElectronicReturnReceipt?.ToDto(),
			Swap: model.Swap?.ToDto(),
			Rop: model.Rop?.ToDto(),
			ReturnVoucher: model.ReturnVoucher?.ToDto()
		);

	internal static ShipmentReturnAdditionalServicesModel ToModel(this ShipmentReturnAdditionalServicesDto dto)
		=> new(
			SendBackClientId: dto.SendBackClientId,
			Rod: dto.Rod?.ToModel(),
			ReturnReceipt: dto.ReturnReceipt?.ToModel(),
			ElectronicReturnReceipt: dto.ElectronicReturnReceipt?.ToModel(),
			Swap: dto.Swap?.ToModel(),
			Rop: dto.Rop?.ToModel(),
			ReturnVoucher: dto.ReturnVoucher?.ToModel()
		);

	internal static ShipmentReturnVoucherAdditionalServiceDto ToDto(this ShipmentReturnVoucherAdditionalServiceModel model)
		=> new(
			ServiceId: model.ServiceId,
			Payer: model.Payer,
			ValidityPeriod: model.ValidityPeriod
		);

	internal static ShipmentReturnVoucherAdditionalServiceModel ToModel(this ShipmentReturnVoucherAdditionalServiceDto dto)
		=> new(
			ServiceId: dto.ServiceId,
			Payer: dto.Payer,
			ValidityPeriod: dto.ValidityPeriod
		);

	internal static ShipmentSwapAdditionalServiceDto ToDto(this ShipmentSwapAdditionalServiceModel model)
		=> new(
			ServiceId: model.ServiceId,
			ParcelsCount: model.ParcelsCount,
			DeclaredValue: model.DeclaredValue,
			Fragile: model.Fragile,
			ReturnToOfficeId: model.ReturnToOfficeId,
			ThirdPartyPayer: model.ThirdPartyPayer
		);

	internal static ShipmentSwapAdditionalServiceModel ToModel(this ShipmentSwapAdditionalServiceDto dto)
		=> new(
			ServiceId: dto.ServiceId,
			ParcelsCount: dto.ParcelsCount,
			DeclaredValue: dto.DeclaredValue,
			Fragile: dto.Fragile,
			ReturnToOfficeId: dto.ReturnToOfficeId,
			ThirdPartyPayer: dto.ThirdPartyPayer
		);

	internal static ShipmentRopAdditionalServiceDto ToDto(this ShipmentRopAdditionalServiceModel model)
		=> new(
			Pallets: [.. model.Pallets.Select(p => new ShipmentRopAdditionalServiceLineDto(p.ServiceId, p.ParcelsCount))],
			ThirdPartyPayer: model.ThirdPartyPayer
		);

	internal static ShipmentRopAdditionalServiceModel ToModel(this ShipmentRopAdditionalServiceDto dto)
		=> new(
			Pallets: [.. dto.Pallets.Select(p => (p.ServiceId, p.ParcelsCount))],
			ThirdPartyPayer: dto.ThirdPartyPayer
		);

	internal static ShipmentRodAdditionalServiceDto ToDto(this ShipmentRodAdditionalServiceModel model)
		=> new(
			Enabled: model.Enabled,
			Comment: model.Comment,
			ReturnToClientId: model.ReturnToClientId,
			ReturnToOfficeId: model.ReturnToOfficeId,
			ThirdPartyPayer: model.ThirdPartyPayer
		);

	internal static ShipmentRodAdditionalServiceModel ToModel(this ShipmentRodAdditionalServiceDto dto)
		=> new(
			Enabled: dto.Enabled,
			Comment: dto.Comment,
			ReturnToClientId: dto.ReturnToClientId,
			ReturnToOfficeId: dto.ReturnToOfficeId,
			ThirdPartyPayer: dto.ThirdPartyPayer
		);

	internal static ShipmentReturnReceiptAdditionalServiceDto ToDto(this ShipmentReturnReceiptAdditionalServiceModel model)
		=> new(
			Enabled: model.Enabled,
			ReturnToClientId: model.ReturnToClientId,
			ReturnToOfficeId: model.ReturnToOfficeId,
			ThirdPartyPayer: model.ThirdPartyPayer
		);

	internal static ShipmentReturnReceiptAdditionalServiceModel ToModel(this ShipmentReturnReceiptAdditionalServiceDto dto)
		=> new(
			Enabled: dto.Enabled,
			ReturnToClientId: dto.ReturnToClientId,
			ReturnToOfficeId: dto.ReturnToOfficeId,
			ThirdPartyPayer: dto.ThirdPartyPayer
		);

	internal static ShipmentElectronicReturnReceiptAdditionalServiceDto ToDto(this ShipmentElectronicReturnReceiptAdditionalServiceModel model)
		=> new(
			RecipientEmails: model.RecipientEmails,
			ThirdPartyPayer: model.ThirdPartyPayer
		);

	internal static ShipmentElectronicReturnReceiptAdditionalServiceModel ToModel(this ShipmentElectronicReturnReceiptAdditionalServiceDto dto)
		=> new(
			RecipientEmails: dto.RecipientEmails,
			ThirdPartyPayer: dto.ThirdPartyPayer
		);

	internal static ShipmentAdditionalServicesDto ToDto(this ShipmentAdditionalServicesModel model)
		=> new(
			Cod: model.Cod?.ToDto(),
			Obdp: model.Obdp?.ToDto(),
			DeclaredValue: model.DeclaredValue?.ToDto(),
			Returns: model.Returns?.ToDto(),
			FixedTimeDelivery: model.FixedTimeDelivery,
			SpecialDeliveryId: model.SpecialDeliveryId,
			DeliveryToFloor: model.DeliveryToFloor
		);

	internal static ShipmentAdditionalServicesModel ToModel(this ShipmentAdditionalServicesDto dto)
		=> new(
			Cod: dto.Cod?.ToModel(),
			Obdp: dto.Obdp?.ToModel(),
			DeclaredValue: dto.DeclaredValue?.ToModel(),
			Returns: dto.Returns?.ToModel(),
			FixedTimeDelivery: dto.FixedTimeDelivery,
			SpecialDeliveryId: dto.SpecialDeliveryId,
			DeliveryToFloor: dto.DeliveryToFloor
		);

	internal static ShipmentServiceDto ToDto(this ShipmentServiceModel model)
		=> new(
			ServiceId: model.ServiceId,
			PickupDate: model.PickupDate?.ToString(DateFormat),
			SaturdayDelivery: model.SaturdayDelivery,
			AutoAdjustPickupDate: model.AutoAdjustPickupDate,
			DefferedValue: model.DeferredDays,
			AdditionalServices: model.AdditionalServices?.ToDto()
		);

	internal static ShipmentServiceModel ToModel(this ShipmentServiceDto dto)
		=> new(
			ServiceId: dto.ServiceId,
			PickupDate: dto.PickupDate is not null ? DateOnly.Parse(dto.PickupDate) : null,
			SaturdayDelivery: dto.SaturdayDelivery,
			AutoAdjustPickupDate: dto.AutoAdjustPickupDate,
			DeferredDays: dto.DefferedValue,
			AdditionalServices: dto.AdditionalServices?.ToModel()
		);

	internal static ShipmentSenderDto ToDto(this ShipmentSenderModel model)
		=> new(
			Phone1: model.Phone1.ToDto(),
			Phone2: model.Phone2?.ToDto(),
			Phone3: model.Phone3?.ToDto(),
			Address: model.Address?.ToDto(),
			ContactName: model.ContactName,
			Email: model.Email,
			ClientId: model.ClientId,
			ClientName: model.ClientName,
			PrivatePerson: model.PrivatePerson,
			DropoffOfficeId: model.DropoffOfficeId,
			DropoffGeoPUDOId: model.DropoffGeoPUDOId
		);

	internal static ShipmentSenderModel ToModel(this ShipmentSenderDto dto, string phone1, string? phone2)
		=> new(
			Phone1: dto.Phone1.ToModel(phone1),
			Phone2: phone2 is null ? dto.Phone2?.ToModel() : dto.Phone2.ToModel(phone2),
			Phone3: dto.Phone3?.ToModel(),
			Address: dto.Address?.ToModel(),
			ContactName: dto.ContactName,
			Email: dto.Email,
			ClientId: dto.ClientId,
			ClientName: dto.ClientName,
			PrivatePerson: dto.PrivatePerson,
			DropoffOfficeId: dto.DropoffOfficeId,
			DropoffGeoPUDOId: dto.DropoffGeoPUDOId
		);

	internal static SecondaryShipmentModel ToModel(this SecondaryShipmentDto dto)
		=> new(
			Id: dto.Id,
			Type: dto.Type,
			Parcels: [.. dto.Parcels.Select(p => (p.Id, p.SeqNo))],
			PickupDate: DateOnly.Parse(dto.PickupDate),
			ServiceId: dto.ServiceId,
			HasScans: dto.HasScans
		);

	internal static ShipmentRecipientDto ToDto(this ShipmentRecipientModel model)
	=> new(
		PrivatePerson: model.PrivatePerson,
		ContactName: model.ContactName,
		Email: model.Email,
		ClientId: model.ClientId,
		ClientName: model.ClientName,
		ObjectName: model.ObjectName,
		PickupOfficeId: model.PickupOfficeId,
		PickupGeoPUDOIf: model.PickupGeoPUDOId,
		AutoSelectNearestOffice: model.AutoSelectNearestOffice,
		AutoSelectNearestOfficePolicy: model.AutoSelectNearestOfficePolicy?.ToDto(),
		Address: model.Address?.ToDto(),
		Phone1: model.Phone1?.ToDto(),
		Phone2: model.Phone2?.ToDto(),
		Phone3: model.Phone3?.ToDto()
	);

	internal static AutoSelectNearestOfficePolicyDto ToDto(this AutoSelectNearestOfficePolicyModel model)
		=> new(
			UnavailableNearestOfficeAction: model.UnavailableNearestOfficeAction,
			OfficeType: model.OfficeType
		);

	internal static ShipmentRecipientModel ToModel(this ShipmentRecipientDto dto)
		=> new(
			PrivatePerson: dto.PrivatePerson,
			ContactName: dto.ContactName,
			Email: dto.Email,
			ClientId: dto.ClientId,
			ClientName: dto.ClientName,
			ObjectName: dto.ObjectName,
			PickupOfficeId: dto.PickupOfficeId,
			PickupGeoPUDOId: dto.PickupGeoPUDOIf,
			AutoSelectNearestOffice: dto.AutoSelectNearestOffice,
			AutoSelectNearestOfficePolicy: dto.AutoSelectNearestOfficePolicy?.ToModel(),
			Address: dto.Address?.ToModel(),
			Phone1: dto.Phone1?.ToModel(),
			Phone2: dto.Phone2?.ToModel(),
			Phone3: dto.Phone3?.ToModel()
		);

	internal static AutoSelectNearestOfficePolicyModel ToModel(this AutoSelectNearestOfficePolicyDto dto)
		=> new(
			UnavailableNearestOfficeAction: dto.UnavailableNearestOfficeAction,
			OfficeType: dto.OfficeType
		);

	internal static ShipmentModel ToModel(this ShipmentDto dto, string phone1, string? phone2)
		=> new(
			Recipient: dto.Recipient.ToModel(),
			Service: dto.Service.ToModel(),
			Content: dto.Content.ToModel(),
			Payment: dto.Payment.ToModel(),
			Sender: dto.Sender.ToModel(phone1, phone2),
			Id: dto.Id,
			ShipmentNote: dto.ShipmentNote,
			Ref1: dto.Ref1,
			Ref2: dto.Ref2,
			Price: dto.Price.ToModel(),
			Delivery: dto.Delivery.ToModel(),
			PrimaryShipment: dto.PrimaryShipment.ToModel(),
			ReturnShipmentId: dto.ReturnShipmentId,
			RedirectShipmentId: dto.RedirectShipmentId,
			PendingShipment: dto.PendingShipment
		);

	internal static ShipmentContentDto ToDto(this ShipmentContentModel model)
		=> new(
			Contents: model.Contents,
			Package: model.Package,
			ParcelsCount: model.ParcelsCount,
			TotalWeight: model.TotalWeight,
			Documents: model.Documents,
			Palletized: model.Palletized,
			Parcels: [.. model.Parcels?.Select(p => p.ToDto()) ?? []],
			PendingParcels: model.PendingParcels,
			ExciseGoods: model.ExciseGoods,
			Iq: model.Iq,
			GoodsValue: model.GoodsValue,
			GoodsValueCurrencyCode: model.GoodsValueCurrencyCode,
			UitCode: model.UitCode
		);

	internal static ShipmentParcelDto ToDto(this ShipmentParcelModel model)
		=> new(
			Weight: model.Weight,
			Id: model.Id,
			SeqNo: model.SeqNo,
			PackageUniqueNumber: model.PackageUniqueNumber,
			Ref1: model.Ref1,
			Ref2: model.Ref2,
			Size: model.Size?.ToDto(),
			PickupExternalCarrierParcelNumber: model.PickupExternalCarrierParcelNumber?.ToDto(),
			DeliveryExternalCarrierParcelNumber: model.DeliveryExternalCarrierParcelNumber?.ToDto(),
			Goods: null
		);

	internal static ShipmentParcelSizeDto ToDto(this ShipmentParcelSizeModel model)
		=> new(
			Width: model.Width,
			Depth: model.Depth,
			Height: model.Height
		);

	internal static ExternalCarrierParcelNumberDto ToDto(this ExternalCarrierParcelNumberModel model)
		=> new(
			ExternalCarrier: model.ExternalCarrier,
			ParcelNumber: model.ParcelNumber
		);

	internal static ShipmentContentModel ToModel(this ShipmentContentDto dto)
		=> new(
			Contents: dto.Contents,
			Package: dto.Package,
			ParcelsCount: dto.ParcelsCount,
			TotalWeight: dto.TotalWeight,
			Documents: dto.Documents,
			Palletized: dto.Palletized,
			Parcels: [.. dto.Parcels?.Select(p => p.ToModel()) ?? []],
			PendingParcels: dto.PendingParcels,
			ExciseGoods: dto.ExciseGoods,
			Iq: dto.Iq,
			GoodsValue: dto.GoodsValue,
			GoodsValueCurrencyCode: dto.GoodsValueCurrencyCode,
			UitCode: dto.UitCode
		);

	internal static ShipmentParcelModel ToModel(this ShipmentParcelDto dto)
		=> new(
			Weight: dto.Weight,
			Id: dto.Id,
			SeqNo: dto.SeqNo,
			PackageUniqueNumber: dto.PackageUniqueNumber,
			Ref1: dto.Ref1,
			Ref2: dto.Ref2,
			Size: dto.Size?.ToModel(),
			PickupExternalCarrierParcelNumber: dto.PickupExternalCarrierParcelNumber?.ToModel(),
			DeliveryExternalCarrierParcelNumber: dto.DeliveryExternalCarrierParcelNumber?.ToModel()
		);

	internal static ShipmentParcelSizeModel ToModel(this ShipmentParcelSizeDto dto)
		=> new(
			Width: dto.Width,
			Depth: dto.Depth,
			Height: dto.Height
		);

	internal static ExternalCarrierParcelNumberModel ToModel(this ExternalCarrierParcelNumberDto dto)
		=> new(
			ExternalCarrier: dto.ExternalCarrier,
			ParcelNumber: dto.ParcelNumber
		);

	internal static ShipmentDeliveryModel ToModel(this ShipmentDeliveryDto dto)
		=> new(
			Deadline: DateTime.Parse(dto.Deadline),
			DeliveryDateTime: dto.DeliveryDateTime is null ? null : DateTime.Parse(dto.DeliveryDateTime),
			Consignee: dto.Consignee,
			DeliveryNote: dto.DeliveryNote
		);

	internal static ShipmentParcelRefDto ToDto(this ShipmentParcelRefModel model)
		=> new(
			Id: model.Id,
			ExternalCarrierParcelNumber: model.ExternalCarrierParcelNumber,
			FullBarcode: model.FullBarcode
		);

	internal static ShipmentPaymentDto ToDto(this ShipmentPaymentModel model)
		=> new(
			CourierServicePayer: model.CourierServicePayer,
			DeclaredValuePayer: model.DeclaredValuePayer,
			PackagePayer: model.PackagePayer,
			ThirdPartyClientId: model.ThirdPartyClientId,
			DiscountCardId: model.DiscountCardId?.ToDto(),
			SenderBankAccount: model.SenderBankAccount?.ToDto(),
			AdministrativeFee: model.AdministrativeFee
		);

	internal static ShipmentDiscountCardIdDto ToDto(this ShipmentDiscountCardIdModel model)
		=> new(
			ContractId: model.ContractId,
			CardId: model.CardId
		);

	internal static BankAccountDto ToDto(this BankAccountModel model)
		=> new(
			Iban: model.Iban,
			AccountHolder: model.AccountHolder
		);

	internal static ShipmentPaymentModel ToModel(this ShipmentPaymentDto dto)
		=> new(
			CourierServicePayer: dto.CourierServicePayer,
			DeclaredValuePayer: dto.DeclaredValuePayer,
			PackagePayer: dto.PackagePayer,
			ThirdPartyClientId: dto.ThirdPartyClientId,
			DiscountCardId: dto.DiscountCardId?.ToModel(),
			SenderBankAccount: dto.SenderBankAccount?.ToModel(),
			AdministrativeFee: dto.AdministrativeFee
		);

	internal static ShipmentDiscountCardIdModel ToModel(this ShipmentDiscountCardIdDto dto)
		=> new(
			ContractId: dto.ContractId,
			CardId: dto.CardId
		);

	internal static BankAccountModel ToModel(this BankAccountDto dto)
		=> new(
			Iban: dto.Iban,
			AccountHolder: dto.AccountHolder
		);

	internal static PrimaryShipmentModel ToModel(this PrimaryShipmentDto dto)
		=> new(
			Id: dto.Id,
			Type: dto.Type
		);
}
