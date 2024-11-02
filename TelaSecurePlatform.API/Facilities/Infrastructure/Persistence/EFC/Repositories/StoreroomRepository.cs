using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TelaSecurePlatform.API.Facilities.Infrastructure.Persistence.EFC.Repositories;

public class StoreroomRepository(AppDbContext context) : BaseRepository<Storeroom>(context), IStoreroomRepository
{
    //
}