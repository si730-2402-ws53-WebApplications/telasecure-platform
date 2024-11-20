namespace TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

public record CreateFabricCommand(string Name, int WarehouseId, int CategoryId, int Quantity);