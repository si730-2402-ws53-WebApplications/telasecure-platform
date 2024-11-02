using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
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
    public async Task<ClimateSensor?> Handle(CreateClimateSensorCommand command)
    {
        var climateSensor = new ClimateSensor(command);
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
}