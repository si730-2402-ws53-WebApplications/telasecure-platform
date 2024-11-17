namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record UpdateFabricResource(string Name, int StoreroomId, int CategoryId, int Quantity);