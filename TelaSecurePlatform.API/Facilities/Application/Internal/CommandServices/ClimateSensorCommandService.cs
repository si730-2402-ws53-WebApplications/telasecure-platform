﻿using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;

public class ClimateSensorCommandService(
    IClimateSensorRepository climateSensorRepository,
    IUnitOfWork unitOfWork) 
    : IClimateSensorCommandService
{
    //crear climate sensor
    public async Task<ClimateSensor?> Handle(CreateClimateSensorCommand command)
    {
        var climateSensor = new ClimateSensor(command);
        
        //se aplica el constrain para la creacion
        var exists = await climateSensorRepository.FindByNameAndStoreRoomIdAsync(climateSensor.Name, climateSensor.StoreRoomId);
        if (exists) return null;
        
        try
        {
            await climateSensorRepository.AddAsync(climateSensor);
            await unitOfWork.CompleteAsync();
            return climateSensor;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //actualizar
    public async Task<ClimateSensor?> Handle(UpdateClimateSensorCommand command)
    {
        var sensor = await climateSensorRepository.FindByIdAsync(command.ClimateSensorId);
        if (sensor == null) return null;

        try
        {
            sensor.UpdateInformation(command.Name, command.Model, command.Type, command.Image, command.StoreRoomId);
            climateSensorRepository.Update(sensor);
            await unitOfWork.CompleteAsync();
            return sensor;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //eliminar
    public async Task<bool> Handle(DeleteClimateSensorCommand command)
    {
        try
        {
            var climateSensor = await climateSensorRepository.FindByIdAsync(command.ClimateSensorId);
            if (climateSensor == null)
            {
                return false;
            }

            climateSensorRepository.Remove(climateSensor);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}