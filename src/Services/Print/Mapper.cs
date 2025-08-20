using SpeedyNET.Http.Dtos.ParcelToPrint;
using SpeedyNET.Abstractions.Contracts.Print;
using SpeedyNET.Services.Mappers.Shipment;
using SpeedyNET.Services;
using SpeedyNET.Services.Print;

namespace SpeedyNET.Services.Print;

internal static class Mapper
{
	internal static ParcelToPrintDto ToDto(this ParcelToPrintModel model)
		=> new(
			Parcel: model.Parcel.ToDto(),
			AdditionalBarcode: model.AdditionalBarcode?.ToDto()
		);

	internal static ParcelToPrintAdditionalBarcodeDto ToDto(this ParcelToPrintAdditionalBarcodeModel model)
		=> new(
			Value: model.Value,
			Format: model.Format,
			Label: model.Label
		);
}
