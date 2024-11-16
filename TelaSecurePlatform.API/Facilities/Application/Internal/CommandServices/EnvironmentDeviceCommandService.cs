using Microsoft.AspNetCore.Http.HttpResults;
using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;

public class EnvironmentDeviceCommandService(IEnvironmentDeviceRepository environmentDeviceRepository,
    IUnitOfWork unitOfWork) : IEnvironmentDeviceCommandService
{
    //crear nuevo environment device id
    public async Task<EnvironmentDevice?> Handle(CreateEnvironmentDeviceCommand command)
    {
        //validar que el integer sea un tipo de device
        if (!Enum.IsDefined(typeof(EEnvironmentDeviceType), command.Type))
        {
            return null;
        }
        var enviroDevice = new EnvironmentDevice(command);
        try
        {
            await environmentDeviceRepository.AddAsync(enviroDevice);
            await unitOfWork.CompleteAsync();
            return enviroDevice;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //actualizar un environment device
    
    public async Task<EnvironmentDevice?> Handle(UpdateEnvironmentDeviceCommand command)
    {
        var enviroDevice = await environmentDeviceRepository.FindByIdAsync(command.EnvironmentDeviceId);
        if (enviroDevice == null) return null;
        //validar que el integer sea un tipo de device
        if (!Enum.IsDefined(typeof(EEnvironmentDeviceType), command.Type))
            return null;

        try
        {
            enviroDevice.UpdateInformation(command.Name, command.Model, command.Value, command.Type, command.Unit, command.StoreRoomId);
            environmentDeviceRepository.Update(enviroDevice);
            await unitOfWork.CompleteAsync();
            return enviroDevice;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //eliminar un environment device
    
    public async Task<bool> Handle(DeleteEnvironmentDeviceCommand command)
    {
        try
        {
            var enviroDevice = await environmentDeviceRepository.FindByIdAsync(command.EnvironmentDeviceId);
            if (enviroDevice == null) return false;

            environmentDeviceRepository.Remove(enviroDevice);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
}