using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Domain.Repositories;

public interface IEnvironmentDeviceRepository : IBaseRepository<EnvironmentDevice>
{
    Task<bool> FindByNameAndWarehouseIdAsync(string name, string warehouseId);
}