using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.QueryServices;

public class StoreroomQueryService(IStoreroomRepository storeroomRepository) : IStoreroomQueryService
{
    public async Task<IEnumerable<Storeroom>> Handle(GetAllStoreroomsQuery query)
    {
        return await storeroomRepository.ListAsync();
    } 
    
    public async Task<Storeroom?> Handle(GetStoreroomByIdQuery query)
    {
        return await storeroomRepository.FindByIdAsync(query.StoreroomId);
    }
}