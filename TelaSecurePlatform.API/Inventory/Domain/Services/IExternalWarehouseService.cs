namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface IExternalWarehouseService
{
    Task<bool> IsWarehouseIdValid(int warehouseId);
}