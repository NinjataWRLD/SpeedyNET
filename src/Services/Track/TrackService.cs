﻿using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Abstractions.Contracts.Track;
using SpeedyNET.Abstractions.UserConfigs;
using SpeedyNET.Http.Dtos.ShipmentParcels;
using SpeedyNET.Http.Endpoints.Track;

namespace SpeedyNET.Services.Track;

internal class TrackService(
	ITrackEndpoints endpoints,
	IShipmentService shipmentService
) : ITrackService
{
	public async Task<TrackedParcelModel[]> TrackAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string shipmentId,
		bool? lastOperationOnly = null,
		CancellationToken ct = default)
	{
		var shipments = await shipmentService.ShipmentInfoAsync(
			account: account,
			contact: contact,
			shipmentIds: [shipmentId],
			ct: ct
		).ConfigureAwait(false);
		var parcels = shipments.Single().Content.Parcels;

		var response = await endpoints.Track(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			Parcels: [.. parcels?.Select(p => new TrackShipmentParcelRefDto(null, Id: p.Id, null, null)) ?? []],
			LastOperationOnly: lastOperationOnly
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Parcels.Select(p => p.ToModel())];
	}

	public async Task<(long Id, string Url)[]> BulkTrackingDataFiles(
		SpeedyAccount account,
		long? lastProcessedFileId = null,
		CancellationToken ct = default)
	{
		var response = await endpoints.BulkTrackingDataFiles(new(
			UserName: account.Username,
			Password: account.Password,
			Language: account.Language,
			ClientSystemId: account.ClientSystemId,
			LastProcessedFileId: lastProcessedFileId
		), ct).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Parcels.Select(p => (p.Id, p.Url))];
	}
}
