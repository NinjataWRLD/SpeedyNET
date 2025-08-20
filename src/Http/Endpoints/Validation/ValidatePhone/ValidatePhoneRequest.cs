namespace SpeedyNET.Http.Endpoints.Validation.ValidatePhone;

internal record ValidatePhoneRequest(
	string UserName,
	string Password,
	string Number,
	string? Language,
	long? ClientSystemId,
	string? Ext
);
