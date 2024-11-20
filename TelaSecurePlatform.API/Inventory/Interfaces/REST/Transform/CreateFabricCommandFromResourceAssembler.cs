using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public static class CreateFabricCommandFromResourceAssembler
{
    public static CreateFabricCommand ToCommandFromResource(CreateFabricResource resource)
    {
        return new CreateFabricCommand(resource.Name, resource.WarehouseId, resource.CategoryId, resource.Quantity);
    }
}