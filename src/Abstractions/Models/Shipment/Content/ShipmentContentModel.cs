﻿using SpeedyNET.Abstractions.Models.Shipment.Parcel;

namespace SpeedyNET.Abstractions.Models.Shipment.Content;

public record ShipmentContentModel(
	string Contents,
	string Package,
	int? ParcelsCount,
	double? TotalWeight,
	bool? Documents,
	bool? Palletized,
	ShipmentParcelModel[]? Parcels,
	bool? PendingParcels,
	bool? ExciseGoods,
	bool? Iq,
	double? GoodsValue,
	string? GoodsValueCurrencyCode,
	string? UitCode
);
