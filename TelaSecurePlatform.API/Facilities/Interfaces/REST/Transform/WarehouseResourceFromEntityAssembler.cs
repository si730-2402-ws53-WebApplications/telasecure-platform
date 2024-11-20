using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class WarehouseResourceFromEntityAssembler
{
    public static WarehouseResource ToResourceFromEntity(Warehouse entity)
    {
        return new WarehouseResource(entity.Id, entity.Name, entity.Description, entity.Location, entity.Capacity, entity.Contact, entity.Temperature, entity.Humidity);
    }
}