using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Abstractions.Contracts.Track;
using SpeedyNET.Abstractions.Models.Shipment;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Abstractions.UserConfigs;
using SpeedyNET.Http.Dtos.ShipmentParcels;
using SpeedyNET.Http.Dtos.TrackedParcel;
using SpeedyNET.Http.Endpoints.Track;
using SpeedyNET.Http.Endpoints.Track.BulkTrackingDataFiles;
using SpeedyNET.Http.Endpoints.Track.Track;

namespace SpeedyNET.Services.Track;

internal class TrackService(ITrackEndpoints endpoints, IShipmentService shipmentService) : ITrackService
{

	public async Task<(long Id, string Url)[]> BulkTrackingDataFiles(
		SpeedyAccount account,
		long? lastProcessedFileId = null,
		CancellationToken ct = default
	)
	{
		BulkTrackingDataFilesResponse response = await endpoints.BulkTrackingDataFiles(
			request: new(
				UserName: account.Username,
				Password: account.Password,
				Language: account.Language,
				ClientSystemId: account.ClientSystemId,
				LastProcessedFileId: lastProcessedFileId
			),
			ct: ct
		).ConfigureAwait(false);

		response.Error.EnsureNull();
		return [.. response.Parcels.Select(p => (p.Id, p.Url))];
	}

	public async Task<Dictionary<string, ICollection<TrackedParcelModel>>> TrackAsync(
		SpeedyAccount account,
		SpeedyContact contact,
		string[] shipmentIds,
		bool? lastOperationOnly = null,
		CancellationToken ct = default
	)
	{
		ShipmentModel[] shipments = await shipmentService.ShipmentInfoAsync(
			account: account,
			contact: contact,
			shipmentIds: shipmentIds,
			ct: ct
		).ConfigureAwait(false);

		TrackResponse response = await endpoints.Track(
			request: new(
				UserName: account.Username,
				Password: account.Password,
				Language: account.Language,
				ClientSystemId: account.ClientSystemId,
				LastOperationOnly: lastOperationOnly,
				Parcels: [..
					shipments
						.SelectMany(s => s.Content.Parcels ?? [])
						.Select(p => new TrackShipmentParcelRefDto(
							Ref: null,
							Id: p.Id,
							ExternalCarrierParcelNumber: null,
							FullBarcode: null
						))
				]
			),
			ct: ct
		).ConfigureAwait(false);

		response.Error.EnsureNull();

		return GroupTrackedParcelsByShipment(
			shipmentsParcels: shipments.ToDictionary(
				x => x.Id,
				x => x.Content.Parcels ?? []
			),
			trackedParcels: response.Parcels
		);
	}

	private static Dictionary<string, ICollection<TrackedParcelModel>> GroupTrackedParcelsByShipment(
		Dictionary<string, ShipmentParcelModel[]> shipmentsParcels,
		TrackedParcelDto[] trackedParcels
	)
	{
		Dictionary<string, ICollection<TrackedParcelModel>> shipmentsTracks = [];

		foreach (TrackedParcelDto trackedParcel in trackedParcels)
		{
			(string Id, ShipmentParcelModel[] Parcels) = shipmentsParcels.First(
				x => x.Value.Any(x => x.Id == trackedParcel.ParcelId)
			);

			if (shipmentsTracks.TryGetValue(Id, out ICollection<TrackedParcelModel>? tracks))
			{
				tracks.Add(trackedParcel.ToModel());
			}
			else
			{
				shipmentsTracks.Add(Id, [trackedParcel.ToModel()]);
			}
		}

		return shipmentsTracks;
	}
}
