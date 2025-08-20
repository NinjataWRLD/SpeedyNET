using SpeedyNET.Abstractions.Models.Calculation.Sender;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Pickup;

internal interface IPickupService
{
	Task<PickupModel[]> Pickup(SpeedyAccount account, TimeOnly visitEndTime, PickupScope pickupScope = PickupScope.EXPLICIT_SHIPMENT_ID_LIST, DateTime? pickupDateTime = null, bool? autoAdjustPickupDate = null, string[]? explicitShipmentIdList = null, string? contactName = null, string? phoneNumber = null, CancellationToken ct = default);
	Task<string[]> PickupTerms(SpeedyAccount account, int serviceId, DateOnly? startingDate = null, CalculationSenderModel? sender = null, bool senderHasPayment = false, CancellationToken ct = default);
}
