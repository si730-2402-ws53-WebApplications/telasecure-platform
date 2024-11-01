namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record CreateFabricResource(string Name, int StoreroomId, int CategoryId, int Quantity);