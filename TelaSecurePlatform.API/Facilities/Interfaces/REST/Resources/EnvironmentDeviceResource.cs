namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record EnvironmentDeviceResource(int Id, string Name, string Model, int Value, string Type, string Unit, string StoreroomId);