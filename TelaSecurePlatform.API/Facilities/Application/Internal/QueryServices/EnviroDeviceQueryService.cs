using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;

public class EnviroDeviceQueryService(IEnviroDeviceRepository enviroDeviceRepository): IEnviroDeviceQueryService
{
    public async Task<IEnumerable<EnviroDevice>> Handle(GetAllEnviroDevicesQuery query)
    {
        return await enviroDeviceRepository.ListAsync();
    }
    
    public async Task<EnviroDevice?> Handle(GetEnviroDeviceByIdQuery query)
    {
        return await enviroDeviceRepository.FindByIdAsync(query.EnviroDeviceId);
    }
}