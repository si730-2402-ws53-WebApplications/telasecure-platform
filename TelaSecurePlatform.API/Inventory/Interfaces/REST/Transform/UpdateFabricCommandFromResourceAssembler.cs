using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class UpdateFabricCommandFromResourceAssembler
{
    public static UpdateFabricCommand ToCommand(int fabricId, UpdateFabricResource resource)
    {
        return new UpdateFabricCommand(fabricId, resource.Name, resource.StoreroomId, resource.CategoryId, resource.Quantity);
    }
}