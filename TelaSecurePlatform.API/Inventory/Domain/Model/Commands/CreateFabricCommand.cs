namespace TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

public record CreateFabricCommand(string Name, int StoreroomId, int CategoryId, int Quantity);