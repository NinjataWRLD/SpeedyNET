﻿using SpeedyNET.Abstractions.Contracts.Location;
using SpeedyNET.Abstractions.Contracts.Services;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Services.Calculation;
using SpeedyNET.Services.Client;
using SpeedyNET.Abstractions.Models.Shipment;
using SpeedyNET.Services.Services;
using SpeedyNET.Http.Endpoints.Shipment.CreateShipment;
using SpeedyNET.Services;
using SpeedyNET.Services.Shipment;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Abstractions.Contracts.Client;
using SpeedyNET.Core;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Abstractions.Models.Shipment.Secondary;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Cod;
using SpeedyNET.Http.Endpoints.Shipment;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Shipment;

using static Constants;

internal class ShipmentService(
	IShipmentEndpoints endpoints,
	ILocationService locationService,
	IClientService clientService,
	IServicesService servicesService
) : IShipmentService
{
	public async Task<WrittenShipmentModel> CreateShipmentAsync(
		SpeedyAccount account,
		SpeedyPickup pickup,
		SpeedyContact contact,
		string package,
		string contents,
		int parcelCount,
		Payer payer,
		double totalWeight,
		string country,
		string site,
		string street,
		string name,
		string service,
		string? email,
		string? phoneNumber,
		CancellationToken ct = default
	)
	{
		int dropoffCountryId = await locationService.GetCountryId(account, country, ct).ConfigureAwait(false);
		int pickupCountryId = await locationService.GetCountryId(account, pickup.Country, ct).ConfigureAwait(false);

		long dropoffSiteId = await locationService.GetSiteId(account, dropoffCountryId, site, ct).ConfigureAwait(false);
		long pickupSiteId = await locationService.GetSiteId(account, pickupCountryId, pickup.City, ct).ConfigureAwait(false);

		street.Discombobulate(out string dropoffStreetName, out string _);
		pickup.Street.Discombobulate(out string pickupStreetName, out string _);

		long dropoffStreetId = await locationService.GetStreetId(account, dropoffSiteId, dropoffStreetName, ct).ConfigureAwait(false);
		long pickupStreetId = await locationService.GetStreetId(account, pickupSiteId, pickupStreetName, ct).ConfigureAwait(false);

		var dropoffOffice = await locationService.GetOfficeId(account, dropoffCountryId, dropoffSiteId, dropoffStreetId, ct).ConfigureAwait(false);
		var pickupOffice = await locationService.GetOfficeId(account, pickupCountryId, pickupSiteId, pickupStreetId, ct).ConfigureAwait(false);

		int serviceId = await servicesService.GetServiceId(account, service, ct).ConfigureAwait(false);
		long clientId = await clientService.GetOwnClientIdAsync(account, ct).ConfigureAwait(false);

		CreateShipmentRequest request = new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			ShipmentNote: null,
			Sender: new(
				ClientId: clientId,
				DropoffOfficeId: dropoffOffice.OfficeId,
				ContactName: name,
				Email: contact.Email,
				Phone1: new(contact.PhoneNumber1, null),
				Phone2: !string.IsNullOrWhiteSpace(contact.PhoneNumber2) ? new(contact.PhoneNumber2, null) : null,
				Phone3: null,
				DropoffGeoPUDOId: null,
				Address: null,
				ClientName: null,
				PrivatePerson: null
			),
			Recipient: new(
				ClientId: clientId,
				PickupOfficeId: pickupOffice.OfficeId,
				Phone1: phoneNumber is not null ? new(phoneNumber, null) : null,
				Email: email,
				Phone2: null,
				Phone3: null,
				AutoSelectNearestOffice: null,
				AutoSelectNearestOfficePolicy: null,
				ContactName: null,
				ClientName: null,
				ObjectName: null,
				PrivatePerson: null,
				Address: null,
				PickupGeoPUDOIf: null
			),
			Service: new(
				ServiceId: serviceId,
				PickupDate: null,
				AdditionalServices: null,
				SaturdayDelivery: null
			),
			Content: new(
				Package: package,
				Contents: contents,
				ParcelsCount: parcelCount,
				TotalWeight: totalWeight,
				Parcels: null,
				Palletized: null,
				PendingParcels: null,
				Documents: null,
				ExciseGoods: null,
				Iq: null,
				GoodsValue: null,
				GoodsValueCurrencyCode: null,
				UitCode: null
			),
			Payment: new(
				CourierServicePayer: payer,
				DeclaredValuePayer: null,
				PackagePayer: null,
				ThirdPartyClientId: null,
				DiscountCardId: null,
				SenderBankAccount: null,
				AdministrativeFee: null
			),
			Id: null,
			Ref1: null,
			Ref2: null,
			ConsolidationRef: null,
			RequireUnsuccessfulDeliveryStickerImage: null
		);

		DateOnly today = DateOnly.FromDateTime(DateTime.Now);
		DateOnly[] weekdays = [.. Enumerable.Range(0, 7).Select(today.AddDays)];

		Exception e = new();
		foreach (DateOnly day in weekdays)
		{
			request = request with { Service = request.Service with { PickupDate = day.ToString(DateFormat) } };
			var response = await endpoints.CreateShipmentAsync(request, ct).ConfigureAwait(false);

			try
			{
				response.Error.EnsureNull();
			}
			catch (Exception ex)
			when (ex is SpeedyInvalidPickupOfficeException or SpeedyInvalidDropOffOfficeException)
			{
				e = ex;
				if (weekdays.Last().Day == day.Day)
				{
					throw;
				}

				continue;
			}

			return new(
				Id: response.Id,
				Parcels: [.. response.Parcels.Select(p => p.ToModel())],
				Price: response.Price.ToModel(),
				PickupDate: DateOnly.Parse(response.PickupDate),
				DeliveryDeadline: DateTime.Parse(response.DeliveryDeadline)
			);
		}

		throw e;
	}

	public async Task CancelShipmentAsync(
		SpeedyAccount account,
		string shipmentId,
		string comment,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.CancelShipmentAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			ShipmentId: shipmentId,
			Comment: comment
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
	}

	public async Task<CreatedShipmentParcelModel> AddParcelAsync(
		SpeedyAccount account,
		string shipmentId,
		ShipmentParcelModel parcel,
		ShipmentCodFiscalReceiptItemModel[] codFiscalReceiptItems,
		double declaredValueAmount,
		double? codAmount = null,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.AddParcelShipmentAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			ShipmentId: shipmentId,
			Parcel: parcel.ToDto(),
			DeclaredValueAmount: declaredValueAmount,
			CodFiscalReceiptItems: [.. codFiscalReceiptItems.Select(i => i.ToDto())],
			CodAmount: codAmount
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Parcel.ToModel();
	}

	public async Task<WrittenShipmentModel> FinalizePendingShipmentAsync(
		SpeedyAccount account,
		string shipmentId,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.FinalizePendingShipmentAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			ShipmentId: shipmentId
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return new(
			Id: response.Id,
			Parcels: [.. response.Parcels.Select(p => p.ToModel())],
			Price: response.Price.ToModel(),
			PickupDate: DateOnly.Parse(response.PickupDate),
			DeliveryDeadline: DateTime.Parse(response.DeliveryDeadline)
		);
	}

	public async Task<ShipmentModel[]> ShipmentInfoAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string[] shipmentIds,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.ShipmentInfoAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			ShipmentIds: shipmentIds
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Shipments.Select(d => d.ToModel(contact.PhoneNumber1, contact.PhoneNumber2))];
	}

	public async Task<SecondaryShipmentModel[]> SecondaryShipmentAsync(
		SpeedyAccount account,
		string shipmentId,
		ShipmentType[] types,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.SecondaryShipmentAsync(shipmentId, new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Types: types
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Shipments.Select(d => d.ToModel())];
	}

	public async Task<WrittenShipmentModel> UpdateShipmentAsync(
		SpeedyAccount account,
		string shipmentId,
		WriteShipmentModel model,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.UpdateShipmentAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Id: shipmentId,
			Recipient: model.Recipient.ToDto(),
			Service: model.Service.ToDto(),
			Content: model.Content.ToDto(),
			Payment: model.Payment.ToDto(),
			Sender: model.Sender?.ToDto(),
			ShipmentNote: model.ShipmentNote,
			Ref1: model.Ref1,
			Ref2: model.Ref2,
			ConsolidationRef: model.ConsolidationRef,
			RequireUnsuccessfulDeliveryStickerImage: model.RequireUnsuccessfulDeliveryStickerImage
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return new(
			Id: response.Id,
			Parcels: [.. response.Parcels.Select(p => p.ToModel())],
			Price: response.Price.ToModel(),
			PickupDate: DateOnly.Parse(response.PickupDate),
			DeliveryDeadline: DateTime.Parse(response.DeliveryDeadline)
		);
	}

	public async Task<WrittenShipmentModel> UpdateShipmentPropertiesAsync(
		SpeedyAccount account,
		string shipmentId,
		Dictionary<string, string> properties,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.UpdateShipmentPropertiesAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Id: shipmentId,
			Properties: properties
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return new(
			Id: response.Id,
			Parcels: [.. response.Parcels.Select(p => p.ToModel())],
			Price: response.Price.ToModel(),
			PickupDate: DateOnly.Parse(response.PickupDate),
			DeliveryDeadline: DateTime.Parse(response.DeliveryDeadline)
		);
	}

	public async Task<string[]> FindParcelsByRefAsync(
		SpeedyAccount account,
		string @ref,
		int searchInRef,
		bool? shipmentsOnly = null,
		bool? includeReturns = null,
		DateTime? fromDateTime = null,
		DateTime? toDateTime = null,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.FindParcelsByRefAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Ref: @ref,
			SearchInRef: searchInRef,
			ShipmentsOnly: shipmentsOnly,
			IncludeReturns: includeReturns,
			FromDateTime: fromDateTime?.ToString(DateTimeFormat),
			ToDateTime: toDateTime?.ToString(DateTimeFormat)
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return response.Barcodes;
	}

	public async Task HandoverToCourierAsync(
		SpeedyAccount account,
		(DateTime DateTime, ShipmentParcelRefModel Parcel)[] parcels,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.HandoverToCourierAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Parcels: [.. parcels.Select(p => p.ToDto())]
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
	}

	public async Task HandoverToMidwayCarrierAsync(
		SpeedyAccount account,
		(DateTime DateTime, ShipmentParcelRefModel Parcel)[] parcels,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.HandoverToMidwayCarrierAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Parcels: [.. parcels.Select(p => p.ToDto())]
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
	}

	public async Task<BarcodeInformationModel> BarcodeInformationAsync(
		SpeedyAccount account,
		ShipmentParcelRefModel parcel,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.BarcodeInformationAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Parcel: parcel.ToDto()
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return new(
			LabelInfo: response.LabelInfo.ToModel(),
			PrimaryShipment: response.PrimaryShipment.ToModel(),
			PrimaryParcelId: response.PrimaryParcelId,
			ReturnShipmentId: response.ReturnShipmentId,
			ReturnParcelId: response.ReturnParcelId,
			RedirectShipmentId: response.RedirectShipmentId,
			RedirectParcelId: response.RedirectParcelId,
			InitialShipmentId: response.InitialShipmentId,
			InitialParcelId: response.InitialParcelId
		);
	}
}
