namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record UpdateEnvironmentDeviceResource(string Name, string Model, int Value, string Type, string Unit, string StoreRoomId);