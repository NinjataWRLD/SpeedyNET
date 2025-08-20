﻿namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rod;

public record ShipmentRodAdditionalServiceModel(
	bool Enabled,
	long? ReturnToClientId,
	int? ReturnToOfficeId,
	bool? ThirdPartyPayer,
	string? Comment
);
