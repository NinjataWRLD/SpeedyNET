﻿using SpeedyNET.Http.Endpoints.Calculation;
using SpeedyNET.Http.Endpoints.Client;
using Refit;
using System.Text.Json;
using System.Text.Json.Serialization;
using SpeedyNET.Http.Endpoints.Print;
using SpeedyNET.Http.Endpoints.Location;
using SpeedyNET.Http.Endpoints.Payment;
using SpeedyNET.Http.Endpoints.Pickup;
using SpeedyNET.Http.Endpoints.Services;
using SpeedyNET.Http.Endpoints.Shipment;
using SpeedyNET.Http.Endpoints.Track;
using SpeedyNET.Http.Endpoints.Validation;

#pragma warning disable IDE0130
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	private static string GetBaseAddress(string url) => $"https://api.speedy.bg/v1/{url}";
	private static RefitSettings Settings
	{
		get
		{
			JsonSerializerOptions options = new()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};
			options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseUpper));

			return new(
				contentSerializer: new SystemTextJsonContentSerializer(options),
				urlParameterFormatter: null,
				formUrlEncodedParameterFormatter: null
			);
		}
	}

	public static IServiceCollection AddShipmentClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IShipmentEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("shipment")));

		return services;
	}

	public static IServiceCollection AddPrintClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IPrintEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("print")));

		return services;
	}

	public static IServiceCollection AddTrackClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<ITrackEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("track")));

		return services;
	}

	public static IServiceCollection AddPickupClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IPickupEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("pickup")));

		return services;
	}

	public static IServiceCollection AddLocationClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<ILocationEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("location")));

		return services;
	}

	public static IServiceCollection AddCalculationClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<ICalculationEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("calculate")));

		return services;
	}

	public static IServiceCollection AddClientClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IClientEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("client")));

		return services;
	}

	public static IServiceCollection AddValidationClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IValidationEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("validation")));

		return services;
	}

	public static IServiceCollection AddServicesClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IServicesEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("services")));

		return services;
	}

	public static IServiceCollection AddPaymentClient(this IServiceCollection services)
	{
		services
			.AddRefitClient<IPaymentEndpoints>(Settings)
			.ConfigureHttpClient(c => c.BaseAddress = new(GetBaseAddress("payments")));

		return services;
	}
}
