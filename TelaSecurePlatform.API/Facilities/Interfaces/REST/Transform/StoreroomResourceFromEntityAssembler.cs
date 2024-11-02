using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class StoreroomResourceFromEntityAssembler
{
    public static StoreroomResource ToResourceFromEntity(Storeroom entity)
    {
        return new StoreroomResource(entity.Id, entity.Name, entity.Description, entity.Location, entity.Capacity, entity.Contact, entity.Temperature, entity.Humidity);
    }
}