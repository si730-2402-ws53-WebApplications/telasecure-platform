using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;

public class WarehouseQueryService(IWarehouseRepository warehouseRepository) : IWarehouseQueryService
{
    public async Task<IEnumerable<Warehouse>> Handle(GetAllWarehousesQuery query)
    {
        return await warehouseRepository.ListAsync();
    } 
    
    public async Task<Warehouse?> Handle(GetWarehouseByIdQuery query)
    {
        return await warehouseRepository.FindByIdAsync(query.WarehouseId);
    }
}