using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class ClimateSensorResourceFromEntityAssembler
{
    public static ClimateSensorResource ToResourceFromEntity(ClimateSensor entity)
    {
        return new ClimateSensorResource(
            entity.Id,
            entity.Name,
            entity.Model,
            entity.Type,
            entity.Image,
            entity.StoreRoomId);
    }
}