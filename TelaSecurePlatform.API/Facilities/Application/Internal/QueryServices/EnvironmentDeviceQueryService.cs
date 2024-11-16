using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;

public class EnvironmentDeviceQueryService(IEnvironmentDeviceRepository environmentDeviceRepository): IEnvironmentDeviceQueryService
{
    public async Task<IEnumerable<EnvironmentDevice>> Handle(GetAllEnvironmentDevicesQuery query)
    {
        return await environmentDeviceRepository.ListAsync();
    }
    
    public async Task<EnvironmentDevice?> Handle(GetEnvironmentDeviceByIdQuery query)
    {
        return await environmentDeviceRepository.FindByIdAsync(query.EnvironmentDeviceId);
    }
}