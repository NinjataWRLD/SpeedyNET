using SpeedyNET.Abstractions.Contracts.Calculation;
using SpeedyNET.Abstractions.Contracts.Client;
using SpeedyNET.Abstractions.Contracts.Location;
using SpeedyNET.Abstractions.Contracts.Payment;
using SpeedyNET.Abstractions.Contracts.Pickup;
using SpeedyNET.Abstractions.Contracts.Print;
using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Abstractions.Contracts.Track;
using SpeedyNET.Abstractions.Contracts.Validation;
using SpeedyNET.Services.Calculation;
using SpeedyNET.Services.Client;
using SpeedyNET.Services.Location;
using SpeedyNET.Services.Payment;
using SpeedyNET.Services.Pickup;
using SpeedyNET.Services.Services;
using SpeedyNET.Services.Track;

#pragma warning disable IDE0130
namespace Microsoft.Extensions.DependencyInjection;

using SpeedyNET.Sdk;
using SpeedyNET.Services.Print;
using SpeedyNET.Services.Shipment;
using SpeedyNET.Services.Validation;

public static class DependencyInjection
{
	public static IServiceCollection AddSpeedyService(this IServiceCollection services, Func<IServiceProvider, SpeedyOptions> optionsFunc)
		=> services
			.AddSpeedyShipment()
			.AddSpeedyPrint()
			.AddSpeedyTrack()
			.AddSpeedyPickup()
			.AddSpeedyLocation()
			.AddSpeedyCalculation()
			.AddSpeedyClient()
			.AddSpeedyValidation()
			.AddSpeedyServices()
			.AddSpeedyPayment()
			.AddScoped(optionsFunc)
			.AddScoped<ISpeedyService, SpeedyService>();

	private static IServiceCollection AddSpeedyShipment(this IServiceCollection services)
	{
		services.AddShipmentClient();
		services.AddScoped<IShipmentService, ShipmentService>();

		return services;
	}

	private static IServiceCollection AddSpeedyPrint(this IServiceCollection services)
	{
		services.AddPrintClient();
		services.AddScoped<IPrintService, PrintService>();

		return services;
	}

	private static IServiceCollection AddSpeedyTrack(this IServiceCollection services)
	{
		services.AddTrackClient();
		services.AddScoped<ITrackService, TrackService>();

		return services;
	}

	private static IServiceCollection AddSpeedyPickup(this IServiceCollection services)
	{
		services.AddPickupClient();
		services.AddScoped<IPickupService, PickupService>();

		return services;
	}

	private static IServiceCollection AddSpeedyLocation(this IServiceCollection services)
	{
		services.AddLocationClient();
		services.AddScoped<ILocationService, LocationService>();

		services.AddScoped<BlockService>();
		services.AddScoped<ComplexService>();
		services.AddScoped<CountryService>();
		services.AddScoped<OfficeService>();
		services.AddScoped<PointOfInterestService>();
		services.AddScoped<PostCodeService>();
		services.AddScoped<SiteService>();
		services.AddScoped<StateService>();
		services.AddScoped<StreetService>();

		return services;
	}

	private static IServiceCollection AddSpeedyCalculation(this IServiceCollection services)
	{
		services.AddCalculationClient();
		services.AddScoped<ICalculationService, CalculationService>();

		return services;
	}

	private static IServiceCollection AddSpeedyClient(this IServiceCollection services)
	{
		services.AddClientClient();
		services.AddScoped<IClientService, ClientService>();

		return services;
	}

	private static IServiceCollection AddSpeedyValidation(this IServiceCollection services)
	{
		services.AddValidationClient();
		services.AddScoped<IValidationService, ValidationService>();

		return services;
	}

	private static IServiceCollection AddSpeedyServices(this IServiceCollection services)
	{
		services.AddServicesClient();
		services.AddScoped<IServicesService, ServicesService>();

		return services;
	}

	private static IServiceCollection AddSpeedyPayment(this IServiceCollection services)
	{
		services.AddPaymentClient();
		services.AddScoped<IPaymentService, PaymentService>();

		return services;
	}
}
