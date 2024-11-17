using TelaSecurePlatform.API.Facilities.Interfaces.ACL;
using TelaSecurePlatform.API.Inventory.Domain.Services;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices;

public class ExternalStoreroomService(IStoreroomsContextFacade storeroomsContextFacade): IExternalStoreroomService
{
    public Task<bool> IsStoreroomIdValid(int storeroomId)
    {
        return storeroomsContextFacade.IsIdValid(storeroomId);
    }
}