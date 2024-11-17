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
    
    public async Task<Fabric?> Handle(UpdateFabricCommand command)
    {
        var fabric = await fabricRepository.FindByIdAsync(command.Id);
        if (fabric == null)
        {
            return null;
        }
        fabric.UpdateInformation(command.Name, command.StoreroomId, command.CategoryId, command.Quantity);
        if (!await externalStoreroomService.IsStoreroomIdValid(command.StoreroomId))
        {
            return null;
        }
        await unitOfWork.CompleteAsync();
        return fabric;
    }
    
    public async Task<bool> Handle(DeleteFabricCommand command)
    {
        var fabric = await fabricRepository.FindByIdAsync(command.FabricId);
        if (fabric == null)
        {
            return false;
        }
        fabricRepository.Remove(fabric);
        await unitOfWork.CompleteAsync();
        return true;
    }
}