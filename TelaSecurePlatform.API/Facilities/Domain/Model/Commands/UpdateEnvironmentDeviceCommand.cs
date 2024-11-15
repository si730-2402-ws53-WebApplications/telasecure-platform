namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record UpdateEnvironmentDeviceCommand(int EnvironmentDeviceId, string Name, string Model, int Value, string Type, string Unit, string StoreRoomId);