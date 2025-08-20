namespace SpeedyNET.Abstractions.Models.Shipment.Payment;

public record BankAccountModel(
	string Iban,
	string AccountHolder
);
