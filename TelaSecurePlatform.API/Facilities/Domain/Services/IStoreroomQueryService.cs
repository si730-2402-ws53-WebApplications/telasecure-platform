using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IStoreroomQueryService
{
    
    Task<IEnumerable<Storeroom>> Handle(GetAllStoreroomsQuery query);
    
    Task<Storeroom?> Handle(GetStoreroomByIdQuery query);
}