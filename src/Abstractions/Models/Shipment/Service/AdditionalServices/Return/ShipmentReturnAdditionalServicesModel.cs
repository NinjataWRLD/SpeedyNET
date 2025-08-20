using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.ElectronicReceipt;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Receipt;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rod;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Rop;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Swap;
using SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return.Voucher;

namespace SpeedyNET.Abstractions.Models.Shipment.Service.AdditionalServices.Return;

public record ShipmentReturnAdditionalServicesModel(
	long? SendBackClientId,
	ShipmentRodAdditionalServiceModel? Rod,
	ShipmentReturnReceiptAdditionalServiceModel? ReturnReceipt,
	ShipmentElectronicReturnReceiptAdditionalServiceModel? ElectronicReturnReceipt,
	ShipmentSwapAdditionalServiceModel? Swap,
	ShipmentRopAdditionalServiceModel? Rop,
	ShipmentReturnVoucherAdditionalServiceModel? ReturnVoucher
);
