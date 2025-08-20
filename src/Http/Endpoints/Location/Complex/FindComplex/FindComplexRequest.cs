﻿namespace SpeedyNET.Http.Endpoints.Location.Complex.FindComplex;

internal record FindComplexRequest(
	string UserName,
	string Password,
	int SiteId,
	string? Language,
	long? ClientSystemId,
	string? Name,
	string? Type
);
