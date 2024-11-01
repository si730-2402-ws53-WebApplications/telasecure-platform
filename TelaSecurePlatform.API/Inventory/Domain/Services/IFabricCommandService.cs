using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface IFabricCommandService
{
    Task<Fabric?> Handle(CreateFabricCommand command);
}