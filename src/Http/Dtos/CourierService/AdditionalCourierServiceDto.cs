namespace SpeedyNET.Http.Dtos.CourierService;

/// <param name="Allowance">
///     Allowance for the additional courier service.
///     <br />
///     Required: Yes.
/// </param>
internal record AdditionalCourierServiceDto(
	Allowance Allowance
);
