using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class EnvironmentDeviceResourceFromEntityAssembler 
{
    public static EnvironmentDeviceResource ToResourceFromEntity(EnvironmentDevice entity)
    {
        return new EnvironmentDeviceResource(
            entity.Id,
            entity.Name,
            entity.Model,
            entity.Value,
            entity.Type,
            entity.Unit,
            entity.WarehouseId);
    }
}