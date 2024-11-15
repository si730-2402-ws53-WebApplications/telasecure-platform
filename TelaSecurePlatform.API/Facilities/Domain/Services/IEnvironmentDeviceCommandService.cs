using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IEnvironmentDeviceCommandService
{
    Task<EnvironmentDevice?> Handle(CreateEnvironmentDeviceCommand command);
    Task<EnvironmentDevice?> Handle(UpdateEnvironmentDeviceCommand command);
    Task<bool> Handle(DeleteEnvironmentDeviceCommand command);
}