﻿namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.DeclaredValue;

public record ShipmentDeclaredValueAdditionalServiceModel(
	double Amount,
	bool? Fragile,
	bool? IgnoreIfNotApplicable
);
