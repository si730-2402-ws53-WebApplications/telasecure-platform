using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Domain.Repositories;

public interface IWarehouseRepository : IBaseRepository<Warehouse>
{
    Task<Warehouse?> FindWarehouseByNameAsync(int warehouseId);
}