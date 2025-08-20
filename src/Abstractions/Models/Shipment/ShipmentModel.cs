using SpeedyNET.Abstractions.Models.Shipment.Content;
using SpeedyNET.Abstractions.Models.Shipment.Delivery;
using SpeedyNET.Abstractions.Models.Shipment.Payment;
using SpeedyNET.Abstractions.Models.Shipment.Price;
using SpeedyNET.Abstractions.Models.Shipment.Primary;
using SpeedyNET.Abstractions.Models.Shipment.Recipient;
using SpeedyNET.Abstractions.Models.Shipment.Sender;
using SpeedyNET.Abstractions.Models.Shipment.Service;

namespace SpeedyNET.Abstractions.Models.Shipment;

public record ShipmentModel(
	string Id,
	ShipmentSenderModel Sender,
	ShipmentRecipientModel Recipient,
	ShipmentServiceModel Service,
	ShipmentContentModel Content,
	ShipmentPaymentModel Payment,
	string ShipmentNote,
	string Ref1,
	string Ref2,
	ShipmentPriceModel Price,
	ShipmentDeliveryModel Delivery,
	PrimaryShipmentModel PrimaryShipment,
	string ReturnShipmentId,
	string RedirectShipmentId,
	bool PendingShipment
);
