using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record CreateEnvironmentDeviceResource(string Name, string Model, int Value, EEnvironmentDeviceType Type, string Unit, string StoreroomId);