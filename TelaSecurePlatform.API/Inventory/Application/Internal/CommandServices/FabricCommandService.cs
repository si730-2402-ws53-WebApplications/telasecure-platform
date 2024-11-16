using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.CommandServices;

public class FabricCommandService(
    IFabricRepository fabricRepository,
    IExternalStoreroomService externalStoreroomService,
    IUnitOfWork unitOfWork)
: IFabricCommandService
{
    public async Task<Fabric?> Handle(CreateFabricCommand command)
    {
        var fabric = new Fabric(command.Name, command.StoreroomId, command.CategoryId, command.Quantity);
        if (!await externalStoreroomService.IsStoreroomIdValid(command.StoreroomId))
        {
            return null;
        }
        await fabricRepository.AddAsync(fabric);
        await unitOfWork.CompleteAsync();
        return fabric;
    }
}