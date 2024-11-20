using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.ACL;

namespace TelaSecurePlatform.API.Facilities.Application.ACL;

public class WarehousesContextFacade(
    IWarehouseCommandService warehouseCommandService,
    IWarehouseQueryService warehouseQueryService
    ): IWarehousesContextFacade
{
    public async Task<bool> IsIdValid(int warehouseId)
    {
        var getWarehouseByIdQuery = new GetWarehouseByIdQuery(warehouseId);
        var warehouse = await warehouseQueryService.Handle(getWarehouseByIdQuery);
        if (warehouse == null) return false;
        return true;
    }
}