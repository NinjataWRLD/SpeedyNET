﻿using SpeedyNET.Abstractions.Contracts.Print;
using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Services;
using SpeedyNET.Services.Shipment;
using SpeedyNET.Http.Dtos.ParcelToPrint;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Services.Print;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Http.Endpoints.Print;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Services.Print;

internal class PrintService(IPrintEndpoints endpoints, IShipmentService shipmentService) : IPrintService
{
	public async Task<byte[]> PrintAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string shipmentId,
		PaperSize paperSize = PaperSize.A4,
		PaperFormat format = PaperFormat.pdf,
		Dpi dpi = Dpi.dpi203,
		AdditionalWaybillSenderCopy additionalWaybillSenderCopy = AdditionalWaybillSenderCopy.NONE,
		string? printerName = null,
		CancellationToken ct = default
	)
	{
		var shipments = await shipmentService.ShipmentInfoAsync(
			account: account,
			contact: contact,
			shipmentIds: [shipmentId],
			ct: ct
		).ConfigureAwait(false);
		var parcels = shipments.Single().Content.Parcels;

		var response = await endpoints.PrintAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			PrinterName: printerName,
			Format: format,
			PaperSize: paperSize,
			Dpi: dpi,
			AdditionalWaybillSenderCopy: additionalWaybillSenderCopy,
			Parcels: [.. parcels?.Select(p => new ParcelToPrintDto(new(p.Id, null, null), null)) ?? []]
		), ct).ConfigureAwait(false);

		response.EnsureSuccessStatusCode();
		using MemoryStream stream = new();
		await response.Content.CopyToAsync(stream, ct).ConfigureAwait(false);
		return stream.ToArray();
	}

	public async Task<(byte[] Data, LabelInfoModel[] PrintLabelsInfo)> ExtendedPrintAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string shipmentId,
		PaperSize paperSize,
		PaperFormat format = PaperFormat.pdf,
		Dpi dpi = Dpi.dpi203,
		AdditionalWaybillSenderCopy additionalWaybillSenderCopy = AdditionalWaybillSenderCopy.NONE,
		string? printerName = null,
		CancellationToken ct = default
	)
	{
		var shipments = await shipmentService.ShipmentInfoAsync(
			account: account,
			contact: contact,
			shipmentIds: [shipmentId],
			ct: ct
		).ConfigureAwait(false);
		var parcels = shipments.Single().Content.Parcels;

		var response = await endpoints.ExtendedPrintAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			PrinterName: printerName,
			Format: format,
			PaperSize: paperSize,
			Dpi: dpi,
			AdditionalWaybillSenderCopy: additionalWaybillSenderCopy,
			Parcels: [.. parcels?.Select(p => new ParcelToPrintDto(new(p.Id, null, null), null)) ?? []]
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return (
			response.Data,
			[.. response.PrintLabelsInfo.Select(i => i.ToModel())]
		);
	}

	public async Task<LabelInfoModel[]> LabelInfoAsync(
		SpeedyAccount account,
		ShipmentParcelRefModel[] parcels,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.LabelInfoAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Parcels: [.. parcels.Select(p => p.ToDto())]
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.PrintLabelsInfo.Select(i => i.ToModel())];
	}

	public async Task<byte[]> PrintVoucherAsync(
		SpeedyAccount account,
		string[] shipmentIds,
		string? printerName = null,
		PaperFormat format = PaperFormat.pdf,
		Dpi dpi = Dpi.dpi203,
		CancellationToken ct = default
	)
	{
		var response = await endpoints.PrintVoucherAsync(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			PrinterName: printerName,
			Format: format,
			Dpi: dpi,
			ShipmentIds: shipmentIds
		), ct).ConfigureAwait(false);

		using MemoryStream stream = new();
		await response.Content.CopyToAsync(stream, ct).ConfigureAwait(false);
		return stream.ToArray();
	}
}
