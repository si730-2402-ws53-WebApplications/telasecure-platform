using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IEnviroDeviceQueryService
{
    Task<IEnumerable<EnviroDevice>> Handle(GetAllEnviroDevicesQuery query);

    Task<EnviroDevice> Handle(GetEnviroDeviceByIdQuery query);
}