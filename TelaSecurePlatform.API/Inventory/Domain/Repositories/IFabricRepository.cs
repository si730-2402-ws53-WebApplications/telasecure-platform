using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Inventory.Domain.Repositories;

public interface IFabricRepository : IBaseRepository<Fabric>
{
    Task<IEnumerable<Fabric>> FindByCategoryIdAsync(int categoryId);
}