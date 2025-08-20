namespace SpeedyNET.Http.Endpoints.Calculation.Calculation;

using Dtos.CalculationContent;
using Dtos.CalculationRecipient;
using Dtos.CalculationSender;
using Dtos.CalculationService;
using Dtos.ShipmentPayment;

internal record CalculationRequest(
	string UserName,
	string Password,
	CalculationRecipientDto Recipient,
	CalculationServiceDto Service,
	CalculationContentDto Content,
	ShipmentPaymentDto Payment,
	CalculationSenderDto? Sender,
	string? Language,
	long? ClientSystemId
);
