using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IEnvironmentDeviceQueryService
{
    Task<IEnumerable<EnvironmentDevice>> Handle(GetAllEnvironmentDevicesQuery query);

    Task<EnvironmentDevice> Handle(GetEnvironmentDeviceByIdQuery query);
}