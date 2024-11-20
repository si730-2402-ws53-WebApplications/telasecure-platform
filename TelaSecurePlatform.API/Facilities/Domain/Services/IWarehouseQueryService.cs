using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IWarehouseQueryService
{
    
    Task<IEnumerable<Warehouse>> Handle(GetAllWarehousesQuery query);
    
    Task<Warehouse?> Handle(GetWarehouseByIdQuery query);
}