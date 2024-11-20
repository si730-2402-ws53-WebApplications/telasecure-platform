using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public class UpdateWarehouseCommandFromResourceAssembler
{
    public static UpdateWarehouseCommand ToCommand(int warehouseId, UpdateWarehouseResource resource)
    {
        return new UpdateWarehouseCommand(
            warehouseId,
            resource.Name,
            resource.Location,
            resource.Description,
            resource.Capacity,
            new Contact(resource.Phone, resource.Email),
            new Temperature(resource.ActualTemperature, resource.MaximumTemperature, resource.MinimumTemperature, resource.TemperatureUnit),
            new Humidity(resource.ActualHumidity, resource.MaximumHumidity, resource.MinimumHumidity, resource.HumidityUnit)
        );
    }
}