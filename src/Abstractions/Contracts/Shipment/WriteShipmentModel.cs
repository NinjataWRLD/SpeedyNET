using SpeedyNET.Abstractions.Models.Shipment.Content;
using SpeedyNET.Abstractions.Models.Shipment.Payment;
using SpeedyNET.Abstractions.Models.Shipment.Recipient;
using SpeedyNET.Abstractions.Models.Shipment.Sender;
using SpeedyNET.Abstractions.Models.Shipment.Service;

namespace SpeedyNET.Abstractions.Contracts.Shipment;

public record WriteShipmentModel(
	ShipmentRecipientModel Recipient,
	ShipmentServiceModel Service,
	ShipmentContentModel Content,
	ShipmentPaymentModel Payment,
	ShipmentSenderModel? Sender,
	string? Id,
	string? ShipmentNote,
	string? Ref1,
	string? Ref2,
	string? ConsolidationRef,
	bool? RequireUnsuccessfulDeliveryStickerImage
);
