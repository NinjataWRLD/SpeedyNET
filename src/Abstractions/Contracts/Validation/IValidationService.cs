using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Abstractions.Models;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Validation;

internal interface IValidationService
{
	Task<bool> ValidateAddress(SpeedyAccount account, ShipmentAddressModel address, CancellationToken ct = default);
	Task<bool> ValidatePhone(SpeedyAccount account, PhoneNumberModel phoneNumber, CancellationToken ct = default);
	Task<bool> ValidatePostCode(SpeedyAccount account, string postCode, long? siteId = null, CancellationToken ct = default);
	Task<bool> ValidateShipment(SpeedyAccount account, WriteShipmentModel shipment, CancellationToken ct = default);
}
