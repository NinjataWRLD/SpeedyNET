namespace SpeedyNET.Abstractions.Models.Shipment.Price;

public record MoneyTransferPremiumModel(
	double? Amount,
	double? AmountLocal,
	Payer? Payer
);
