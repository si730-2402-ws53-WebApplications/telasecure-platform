using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Queries;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices.acl;

public class FabricQueryService(IFabricRepository fabricRepository) : IFabricQueryService
{
    public async Task<Fabric?> Handle(GetFabricByIdQuery query)
    {
        return await fabricRepository.FindByIdAsync(query.FabricId);
    }
    
    public async Task<IEnumerable<Fabric>> Handle(GetAllFabricsQuery query)
    {
        return await fabricRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Fabric>> Handle(GetAllFabricsByCategoryIdQuery query)
    {
        return await fabricRepository.FindByCategoryIdAsync(query.CategoryId);
    }
}