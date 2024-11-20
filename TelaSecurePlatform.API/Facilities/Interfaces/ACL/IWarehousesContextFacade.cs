namespace TelaSecurePlatform.API.Facilities.Interfaces.ACL;

public interface IWarehousesContextFacade
{
    Task<bool> IsIdValid(int warehouseId);
}