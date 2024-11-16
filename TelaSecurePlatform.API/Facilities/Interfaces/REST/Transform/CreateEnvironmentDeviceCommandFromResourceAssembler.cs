using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class CreateEnvironmentDeviceCommandFromResourceAssembler
{
    public static CreateEnvironmentDeviceCommand ToCommandFromResource(CreateEnvironmentDeviceResource resource)
    {
        return new CreateEnvironmentDeviceCommand(
            resource.Name,
            resource.Model,
            resource.Value,
            resource.Type,
            resource.Unit,
            resource.StoreroomId);
    }
}