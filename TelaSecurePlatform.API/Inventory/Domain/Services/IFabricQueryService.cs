using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface IFabricQueryService
{
    Task<Fabric?> Handle(GetFabricByIdQuery query);
    Task<IEnumerable<Fabric>> Handle(GetAllFabricsQuery query);
    Task<IEnumerable<Fabric>> Handle(GetAllFabricsByCategoryIdQuery query);
}