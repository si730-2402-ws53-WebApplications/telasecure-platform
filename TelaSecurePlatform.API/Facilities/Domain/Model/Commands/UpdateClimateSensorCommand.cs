namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record UpdateClimateSensorCommand(int ClimateSensorId, string Name, string Model, string Type, string Image, string StoreRoomId);