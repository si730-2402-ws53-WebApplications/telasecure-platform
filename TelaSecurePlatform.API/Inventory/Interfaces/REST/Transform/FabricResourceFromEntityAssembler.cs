using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public static class FabricResourceFromEntityAssembler
{
    public static FabricResource ToResourceFromEntity(Fabric entity)
    {
        return new FabricResource(
            entity.Id,
            entity.Name,
            entity.StoreroomId,
            entity.CategoryId,
            entity.Quantity
        );
    }
}