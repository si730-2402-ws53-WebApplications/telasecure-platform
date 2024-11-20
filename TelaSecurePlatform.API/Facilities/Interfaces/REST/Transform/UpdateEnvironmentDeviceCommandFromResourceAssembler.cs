using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public class UpdateEnvironmentDeviceCommandFromResourceAssembler
{
    public static UpdateEnvironmentDeviceCommand ToCommandFromResource(int environmentDeviceId, UpdateEnvironmentDeviceResource resource)
    {
        return new UpdateEnvironmentDeviceCommand(
            environmentDeviceId,
            resource.Name,
            resource.Model,
            resource.Value,
            resource.Type,
            resource.Unit,
            resource.WarehouseId
        );
    }
}