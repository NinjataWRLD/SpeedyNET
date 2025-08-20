using SpeedyNET.Abstractions.Models.Calculation.Recipient;

namespace SpeedyNET.Abstractions.Models.Calculation.Sender;

public record CalculationSenderModel(
	CalculationAddressLocationModel? AddressLocation,
	long? ClientId,
	bool? PrivatePerson,
	int? DropoffOfficeId,
	string? DropoffGeoPUDOId
);
