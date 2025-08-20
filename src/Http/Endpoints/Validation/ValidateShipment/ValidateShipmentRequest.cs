﻿namespace SpeedyNET.Http.Endpoints.Validation.ValidateShipment;

using Dtos.ShipmentContent;
using Dtos.ShipmentPayment;
using Dtos.ShipmentSenderAndRecipient.ShipmentRecipient;
using Dtos.ShipmentSenderAndRecipient.ShipmentSender;
using Dtos.ShipmentService;

internal record ValidateShipmentRequest(
	// Copied from CreateShipmentRequest
	string UserName,
	string Password,
	ShipmentRecipientDto Recipient,
	ShipmentServiceDto Service,
	ShipmentContentDto Content,
	ShipmentPaymentDto Payment,
	ShipmentSenderDto? Sender,
	string? Language,
	long? ClientSystemId,
	string? Id,
	string? ShipmentNote,
	string? Ref1,
	string? Ref2,
	string? ConsolidationRef,
	bool? RequireUnsuccessfulDeliveryStickerImage
);
