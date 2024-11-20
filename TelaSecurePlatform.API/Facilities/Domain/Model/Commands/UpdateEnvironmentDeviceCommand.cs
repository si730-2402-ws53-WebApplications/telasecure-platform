using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record UpdateEnvironmentDeviceCommand(int EnvironmentDeviceId, string Name, string Model, int Value, EEnvironmentDeviceType Type, string Unit, string WarehouseId);