using SpeedyNET.Abstractions.Contracts.Calculation;
using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Services.Shipment;
using SpeedyNET.Http.Dtos.CalculationContent;
using SpeedyNET.Http.Dtos.CalculationRecipient;
using SpeedyNET.Http.Dtos.CalculationResult;
using SpeedyNET.Http.Dtos.CalculationSender;
using SpeedyNET.Http.Dtos.CalculationService;
using SpeedyNET.Http.Dtos.ShipmentContent.ShipmentParcel;
using SpeedyNET.Services.Mappers.Calculation;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Calculation.Recipient;
using SpeedyNET.Abstractions.Models.Shipment.Content;
using SpeedyNET.Abstractions.Models.Shipment.Service;
using SpeedyNET.Abstractions.Models.Shipment.Recipient;
using SpeedyNET.Abstractions.Models.Shipment.Sender;

namespace SpeedyNET.Services.Calculation;

using static Constants;

internal static class Mapper
{
	internal static CalculationContentDto ToCalculation(this ShipmentContentModel model)
		=> new(
			ParcelsCount: model.ParcelsCount,
			TotalWeight: model.TotalWeight,
			Documents: model.Documents,
			Palletized: model.Palletized,
			Parcels: [.. model.Parcels?.Select(p => p.ToDto()) ?? []]
		);

	internal static CalculationServiceDto ToCalculation(this ShipmentServiceModel model)
		=> new(
			ServiceIds: [model.ServiceId],
			PickupDate: model.PickupDate?.ToString(DateTimeFormat),
			AutoAdjustPickupDate: model.AutoAdjustPickupDate,
			AdditionalServices: model.AdditionalServices?.ToDto(),
			DeferredDays: model.DeferredDays,
			SaturdayDelivery: model.SaturdayDelivery
		);

	internal static CalculationSenderDto ToCalculation(this ShipmentSenderModel model, CalculationAddressLocationModel? location = null)
		=> new(
			AddressLocation: location?.ToDto(),
			ClientId: model.ClientId,
			PrivatePerson: model.PrivatePerson,
			DropoffOfficeId: model.DropoffOfficeId,
			DropoffGeoPUDOId: model.DropoffGeoPUDOId
		);

	internal static CalculationRecipientDto ToCalculation(this ShipmentRecipientModel model, CalculationAddressLocationModel? location = null)
		=> new(
			AddressLocation: location?.ToDto(),
			ClientId: model.ClientId,
			PrivatePerson: model.PrivatePerson,
			PickupOfficeId: model.PickupOfficeId,
			PickupGeoPUDOId: model.PickupGeoPUDOId
		);

	internal static CalculateModel ToModel(this CalculationResultDto dto, CourierServiceModel[] services)
		=> new(
			Service: services.Single(s => s.Id == dto.ServiceId).NameEn,
			AdditionalServices: dto.AdditionalServices?.ToModel(),
			Price: dto.Price.ToModel(),
			PickupDate: dto.PickupDate.ParseDate(),
			DeliveryDeadline: dto.DeliveryDeadline.ParseDateTime()
		);

	internal static ShipmentParcelDto ToParcelDto(this double weight)
		=> new(
			Weight: weight,
			Id: null,
			SeqNo: null,
			PackageUniqueNumber: null,
			Ref1: null,
			Ref2: null,
			Size: null,
			PickupExternalCarrierParcelNumber: null,
			DeliveryExternalCarrierParcelNumber: null,
			Goods: null
		);
}
