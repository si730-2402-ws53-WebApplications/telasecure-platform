using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class CreateClimateSensorCommandFromResourceAssembler
{
    public static CreateClimateSensorCommand ToCommandFromResource(CreateClimateSensorResource resource)
    {
        return new CreateClimateSensorCommand(
            resource.Name,
            resource.Model,
            resource.Type,
            resource.Image,
            resource.StoreRoomId);
    }
}