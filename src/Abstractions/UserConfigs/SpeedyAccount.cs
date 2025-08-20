namespace SpeedyNET.Abstractions.UserConfigs;

public record SpeedyAccount(
	string Username,
	string Password,
	string? Language = null,
	long? ClientSystemId = null
);
