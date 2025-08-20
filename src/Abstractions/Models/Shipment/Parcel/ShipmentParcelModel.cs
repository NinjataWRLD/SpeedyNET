﻿namespace SpeedyNET.Abstractions.Models.Shipment.Parcel;

public record ShipmentParcelModel(
	double Weight,
	string? Id,
	int? SeqNo,
	long? PackageUniqueNumber,
	string? Ref1,
	string? Ref2,
	ShipmentParcelSizeModel? Size,
	ExternalCarrierParcelNumberModel? PickupExternalCarrierParcelNumber,
	ExternalCarrierParcelNumberModel? DeliveryExternalCarrierParcelNumber
);
