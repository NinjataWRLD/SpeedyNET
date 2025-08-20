namespace SpeedyNET.Http.Endpoints.Client.ContractInfo;

using Dtos.CodAdditionalServiceContractInfo;
using Dtos.SpecialDeliveryRequirements;

internal record ContractInfoResponse(
	long Id,
	bool AdministrativeFeeAllowed,
	SpecialDeliveryRequirementsDto? SpecialDeliveryRequirements,
	CodAdditionalServiceContractInfoDto? Cod,
	ErrorDto? Error
);
