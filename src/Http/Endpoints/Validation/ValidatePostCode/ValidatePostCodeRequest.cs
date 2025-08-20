﻿namespace SpeedyNET.Http.Endpoints.Validation.ValidatePostCode;

internal record ValidatePostCodeRequest(
	string UserName,
	string Password,
	string PostCode,
	int? CountryId,
	long? SiteId,
	string? Language,
	long? ClientSystemId
);
