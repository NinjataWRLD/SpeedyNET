﻿namespace SpeedyNET.Abstractions.Contracts.Location;

public record StreetModel(
	long Id,
	long SiteId,
	string Type,
	string TypeEn,
	string Name,
	string NameEn,
	long ActualId,
	string ActualType,
	string ActualTypeEn,
	string ActualName,
	string ActualNameEn
);
