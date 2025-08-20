namespace SpeedyNET.Abstractions.Contracts.Location;

public record StateModel(
	string Id,
	string Name,
	string NameEn,
	string StateAlpha,
	int CountryId
);
