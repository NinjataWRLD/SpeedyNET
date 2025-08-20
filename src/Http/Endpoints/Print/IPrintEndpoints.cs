using Refit;

namespace SpeedyNET.Http.Endpoints.Print;

using ExtendedPrint;
using Print;
using LabelInfo;
using PrintVoucher;

internal interface IPrintEndpoints
{
	[Post("/")]
	Task<HttpResponseMessage> PrintAsync(PrintRequest request, CancellationToken ct = default);

	[Post("/extended")]
	Task<ExtendedPrintResponse> ExtendedPrintAsync(ExtendedPrintRequest request, CancellationToken ct = default);

	[Post("/labelInfo")]
	Task<LabelInfoResponse> LabelInfoAsync(LabelInfoRequest request, CancellationToken ct = default);

	[Post("/voucher")]
	Task<HttpResponseMessage> PrintVoucherAsync(PrintVoucherRequest request, CancellationToken ct = default);
}
