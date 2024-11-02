namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record StoreroomResource(int Id, string Name, string Location, string Description, int Capacity, string Phone, string Email, int ActualTemperature, int MaximumTemperature, int MinimumTemperature, string TemperatureUnit, int ActualHumidity, int MaximumHumidity, int MinimumHumidity, string HumidityUnit);