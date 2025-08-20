using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Sdk;

public record SpeedyOptions(
	SpeedyAccount Account,
	SpeedyPickup Pickup,
	SpeedyContact Contact
);
