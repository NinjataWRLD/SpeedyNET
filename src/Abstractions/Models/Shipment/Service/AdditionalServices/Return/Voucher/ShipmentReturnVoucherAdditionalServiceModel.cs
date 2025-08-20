namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Voucher;

public record ShipmentReturnVoucherAdditionalServiceModel(
	int ServiceId,
	Payer Payer,
	int? ValidityPeriod
);
