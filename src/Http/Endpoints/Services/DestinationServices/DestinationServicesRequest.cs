namespace SpeedyNET.Http.Endpoints.Services.DestinationServices;

using Dtos.CalculationRecipient;
using Dtos.CalculationSender;

internal record DestinationServicesRequest(
	string UserName,
	string Password,
	CalculationRecipientDto Recipient,
	CalculationSenderDto? Sender,
	string? Language,
	long? ClientSystemId,
	string? Date
);
