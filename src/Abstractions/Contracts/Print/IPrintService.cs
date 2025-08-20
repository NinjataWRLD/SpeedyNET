using SpeedyNET.Abstractions.Contracts.Shipment;
using SpeedyNET.Abstractions.Models.Shipment.Parcel;
using SpeedyNET.Abstractions.UserConfigs;

namespace SpeedyNET.Abstractions.Contracts.Print;

internal interface IPrintService
{
	Task<(byte[] Data, LabelInfoModel[] PrintLabelsInfo)> ExtendedPrintAsync(SpeedyAccount account, SpeedyContact contact, string shipmentId, PaperSize paperSize, PaperFormat format = PaperFormat.pdf, Dpi dpi = Dpi.dpi203, AdditionalWaybillSenderCopy additionalWaybillSenderCopy = AdditionalWaybillSenderCopy.NONE, string? printerName = null, CancellationToken ct = default);
	Task<LabelInfoModel[]> LabelInfoAsync(SpeedyAccount account, ShipmentParcelRefModel[] parcels, CancellationToken ct = default);
	Task<byte[]> PrintAsync(SpeedyAccount account, SpeedyContact contact, string shipmentId, PaperSize paperSize = PaperSize.A4, PaperFormat format = PaperFormat.pdf, Dpi dpi = Dpi.dpi203, AdditionalWaybillSenderCopy additionalWaybillSenderCopy = AdditionalWaybillSenderCopy.NONE, string? printerName = null, CancellationToken ct = default);
	Task<byte[]> PrintVoucherAsync(SpeedyAccount account, string[] shipmentIds, string? printerName = null, PaperFormat format = PaperFormat.pdf, Dpi dpi = Dpi.dpi203, CancellationToken ct = default);
}
