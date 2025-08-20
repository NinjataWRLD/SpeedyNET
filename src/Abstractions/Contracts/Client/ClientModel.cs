using SpeedyNET.Abstractions.Models;

namespace SpeedyNET.Abstractions.Contracts.Client;

public record ClientModel(
	long ClientId,
	string ClientName,
	string ObjectName,
	string ContactName,
	AddressModel Address,
	string Email,
	bool PrivatePerson
);
