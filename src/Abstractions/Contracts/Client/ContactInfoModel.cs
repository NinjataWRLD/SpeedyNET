using SpeedyNET.Abstractions.Models.Client;

namespace SpeedyNET.Abstractions.Contracts.Client;

public record ContactInfoModel(
	long Id,
	bool AdministrativeFeeAllowed,
	SpecialDeliveryRequirementsModel? SpecialDeliveryRequirements,
	CodAdditionalServiceContractInfoModel? Cod
);
