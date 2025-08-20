using SpeedyNET.Http.Dtos.CalculationAddressLocation;
using SpeedyNET.Http.Dtos.CalculationContent;
using SpeedyNET.Http.Dtos.CalculationRecipient;
using SpeedyNET.Http.Dtos.CalculationSender;
using SpeedyNET.Http.Dtos.CalculationService;
using SpeedyNET.Services;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Services.Mappers.Calculation;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Calculation.Content;
using SpeedyNET.Abstractions.Models.Calculation.Recipient;
using SpeedyNET.Abstractions.Models.Calculation.Service;
using SpeedyNET.Abstractions.Models.Calculation.Sender;

namespace SpeedyNET.Services.Mappers.Calculation;

using static Constants;

internal static class Mapper
{
	internal static CalculationRecipientDto ToDto(this CalculationRecipientModel model)
		=> new(
			AddressLocation: model.AddressLocation?.ToDto(),
			ClientId: model.ClientId,
			PrivatePerson: model.PrivatePerson,
			PickupOfficeId: model.PickupOfficeId,
			PickupGeoPUDOId: model.PickupGeoPUDOIf
		);

	internal static CalculationAddressLocationDto ToDto(this CalculationAddressLocationModel model)
		=> new(
			CountryId: model.CountryId,
			StateId: model.StateId,
			SiteId: model.SiteId,
			SiteType: model.SiteType,
			SiteName: model.SiteName,
			PostCode: model.PostCode
		);

	internal static CalculationServiceDto ToDto(this CalculationServiceModel model)
		=> new(
			ServiceIds: model.ServiceIds,
			PickupDate: model.PickupDate?.ToString(DateFormat),
			AutoAdjustPickupDate: model.AutoAdjustPickupDate,
			AdditionalServices: model.AdditionalServices?.ToDto(),
			DeferredDays: model.DeferredDays,
			SaturdayDelivery: model.SaturdayDelivery
		);

	internal static CalculationContentDto ToDto(this CalculationContentModel model)
		=> new(
			ParcelsCount: model.ParcelsCount,
			TotalWeight: model.TotalWeight,
			Documents: model.Documents,
			Palletized: model.Palletized,
			Parcels: [.. model.Parcels?.Select(p => p.ToDto()) ?? []]
		);

	internal static CalculationSenderDto ToDto(this CalculationSenderModel model)
		=> new(
			AddressLocation: model.AddressLocation?.ToDto(),
			ClientId: model.ClientId,
			PrivatePerson: model.PrivatePerson,
			DropoffOfficeId: model.DropoffOfficeId,
			DropoffGeoPUDOId: model.DropoffGeoPUDOId
		);
}
