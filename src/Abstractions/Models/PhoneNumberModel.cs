namespace SpeedyNET.Abstractions.Models;

public record PhoneNumberModel(
	string Number,
	string? Extension = default
);
