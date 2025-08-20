using SpeedyNET.Abstractions.Contracts.Pickup;
using SpeedyNET.Http.Dtos.PickupOrder;

namespace SpeedyNET.Services.Pickup;

internal static class Mapper
{
	internal static PickupModel ToModel(this PickupOrderDto dto)
		=> new(
			Id: dto.Id,
			ShipmentIds: dto.ShipmentIds,
			PickupPeriodFrom: dto.PickupPeriodFrom is not null ? DateTime.Parse(dto.PickupPeriodFrom) : null,
			PickupPeriodTo: dto.PickupPeriodTo is not null ? DateTime.Parse(dto.PickupPeriodTo) : null
		);
}
