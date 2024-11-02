namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record CreateStoreroomCommand(string Name, string Location, string Description, int Capacity, string Phone, string Email, int ActualTemperature, int MaximumTemperature, int MinimumTemperature, string TemperatureUnit, int ActualHumidity, int MaximumHumidity, int MinimumHumidity, string HumidityUnit
);