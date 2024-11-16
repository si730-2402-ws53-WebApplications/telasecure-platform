using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Facilities.Interfaces.ACL;

namespace TelaSecurePlatform.API.Facilities.Application.ACL;

public class StoreroomsContextFacade(
    IStoreroomCommandService storeroomCommandService,
    IStoreroomQueryService storeroomQueryService
    ): IStoreroomsContextFacade
{
    public async Task<bool> IsIdValid(int storeroomId)
    {
        var getStoreroomByIdQuery = new GetStoreroomByIdQuery(storeroomId);
        var storeroom = await storeroomQueryService.Handle(getStoreroomByIdQuery);
        if (storeroom == null) return false;
        return true;
    }
}