namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record CreateFabricResource(string Name, int WarehouseId, int CategoryId, int Quantity);