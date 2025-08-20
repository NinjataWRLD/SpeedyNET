namespace SpeedyNET.Abstractions.Contracts.Location;

public record OfficeWorkingTimeScheduleModel(
	DateOnly Date,
	TimeOnly WorkingTimeFrom,
	TimeOnly WorkingTimeTo,
	string SameDayDepartureCutoff,
	bool StandardSchedule
);
