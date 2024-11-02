using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class EnviroDeviceResourceFromEntityAssembler 
{
    public static EnviroDeviceResource ToResourceFromEntity(EnviroDevice entity)
    {
        return new EnviroDeviceResource(
            entity.Id,
            entity.Name,
            entity.Model,
            entity.Value,
            entity.Type,
            entity.Unit,
            entity.StoreRoomId);
    }
}