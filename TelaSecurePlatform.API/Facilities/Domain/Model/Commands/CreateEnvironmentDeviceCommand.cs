using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record CreateEnvironmentDeviceCommand(string Name, string Model, int Value, EEnvironmentDeviceType Type, string Unit, string StoreRoomId);