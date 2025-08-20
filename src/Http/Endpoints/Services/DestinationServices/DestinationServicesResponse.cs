namespace SpeedyNET.Http.Endpoints.Services.DestinationServices;

using Dtos.ExtendedCourierService;

internal record DestinationServicesResponse(
	ExtendedCourierServiceDto[] Services,
	ErrorDto? Error
);
