namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record CreateClimateSensorCommand(string Name, string Model, string Type, string Image, string StoreroomId);