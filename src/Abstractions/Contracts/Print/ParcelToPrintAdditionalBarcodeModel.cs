namespace SpeedyNET.Abstractions.Contracts.Print;

public record ParcelToPrintAdditionalBarcodeModel(
	string Value,
	Format Format,
	string? Label
);
