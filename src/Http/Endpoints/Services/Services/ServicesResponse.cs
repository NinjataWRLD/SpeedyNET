namespace SpeedyNET.Http.Endpoints.Services.Services;

using Dtos.CourierService;

internal record ServicesResponse(
	CourierServiceDto[] Services,
	ErrorDto? Error
);
