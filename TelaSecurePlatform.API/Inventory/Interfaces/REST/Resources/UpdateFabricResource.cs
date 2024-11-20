namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record UpdateFabricResource(string Name, int WarehouseId, int CategoryId, int Quantity);