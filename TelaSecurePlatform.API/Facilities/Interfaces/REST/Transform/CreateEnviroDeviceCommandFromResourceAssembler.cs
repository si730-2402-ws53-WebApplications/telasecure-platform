using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public static class CreateEnviroDeviceCommandFromResourceAssembler
{
    public static CreateEnviroDeviceCommand ToCommandFromResource(CreateEnviroDeviceResource resource)
    {
        return new CreateEnviroDeviceCommand(
            resource.Name,
            resource.Model,
            resource.Value,
            resource.Type,
            resource.Unit,
            resource.StoreroomId);
    }
}