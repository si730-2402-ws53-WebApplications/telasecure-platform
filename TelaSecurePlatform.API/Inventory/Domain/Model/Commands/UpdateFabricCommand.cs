namespace TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

public record UpdateFabricCommand(int Id, string Name, int StoreroomId, int CategoryId, int Quantity);