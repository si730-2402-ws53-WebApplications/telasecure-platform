namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record FabricResource(int Id, string Name, int StoreroomId, int CategoryId, int Quantity);