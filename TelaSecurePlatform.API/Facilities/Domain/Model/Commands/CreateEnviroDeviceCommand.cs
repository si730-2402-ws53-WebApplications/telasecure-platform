namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record CreateEnviroDeviceCommand(string Name, string Model, int Value, string Type, string Unit, string StoreRoomId);