namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record CreateEnviroDeviceResource(string Name, string Model, int Value, string Type, string Unit, string StoreroomId);