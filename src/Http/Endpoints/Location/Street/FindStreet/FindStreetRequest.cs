﻿namespace SpeedyNET.Http.Endpoints.Location.Street.FindStreet;

internal record FindStreetRequest(
	string UserName,
	string Password,
	int SiteId,
	string? Language,
	long? ClientSystemId,
	string? Name,
	string? Type
);
