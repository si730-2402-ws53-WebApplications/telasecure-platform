using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class CreateWarehouseCommandFromResourceAssembler
{
    
    public static CreateWarehouseCommand ToCommandFromResource(CreateWarehouseResource resource)
    {
        return new CreateWarehouseCommand(
            resource.Name,
            resource.Location,
            resource.Description,
            resource.Capacity,
            resource.Phone,
            resource.Email,
            resource.ActualTemperature,
            resource.MaximumTemperature,
            resource.MinimumTemperature,
            resource.TemperatureUnit,
            resource.ActualHumidity,
            resource.MaximumHumidity,
            resource.MinimumHumidity,
            resource.HumidityUnit
        );
    }
    
}