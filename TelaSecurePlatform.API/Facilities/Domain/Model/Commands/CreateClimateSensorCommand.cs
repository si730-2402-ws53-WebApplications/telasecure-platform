using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record CreateClimateSensorCommand(string Name, string Model, EClimateSensorType Type, string Image, string WarehouseId);