namespace SpeedyNET.Http.Endpoints.Location.Postcode.GetAllPostcodes;

internal record GetAllPostcodesRequest(
	string UserName,
	string Password,
	string? Language,
	long? ClientSystemId
);
