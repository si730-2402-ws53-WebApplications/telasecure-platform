using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;

public class ClimateSensorQueryService(IClimateSensorRepository climateSensorRepository): IClimateSensorQueryService
{
    public async Task<IEnumerable<ClimateSensor>> Handle(GetAllClimateSensorsQuery query)
    {
        return await climateSensorRepository.ListAsync();
    }
    
    public async Task<ClimateSensor?> Handle(GetClimateSensorByIdQuery query)
    {
        return await climateSensorRepository.FindByIdAsync(query.ClimateSensorId);
    }
}