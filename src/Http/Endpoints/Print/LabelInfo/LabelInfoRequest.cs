namespace SpeedyNET.Http.Endpoints.Print.LabelInfo;

using Dtos.ShipmentParcels;

internal record LabelInfoRequest(
	string UserName,
	string Password,
	ShipmentParcelRefDto[] Parcels,
	string? Language,
	long? ClientSystemId
);
