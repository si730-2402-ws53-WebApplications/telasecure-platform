using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;

public class EnviroDeviceCommandService(IEnviroDeviceRepository enviroDeviceRepository,
    IUnitOfWork unitOfWork) : IEnviroDeviceCommandService
{
    public async Task<EnviroDevice?> Handle(CreateEnviroDeviceCommand command)
    {
        var enviroDevice = new EnviroDevice(command);
        try
        {
            await enviroDeviceRepository.AddAsync(enviroDevice);
            await unitOfWork.CompleteAsync();
            return enviroDevice;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}