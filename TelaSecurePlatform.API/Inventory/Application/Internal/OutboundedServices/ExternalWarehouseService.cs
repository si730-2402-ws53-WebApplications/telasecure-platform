using TelaSecurePlatform.API.Facilities.Interfaces.ACL;
using TelaSecurePlatform.API.Inventory.Domain.Services;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices;

public class ExternalWarehouseService(IWarehousesContextFacade warehousesContextFacade): IExternalWarehouseService
{
    public Task<bool> IsWarehouseIdValid(int warehouseId)
    {
        return warehousesContextFacade.IsIdValid(warehouseId);
    }
}