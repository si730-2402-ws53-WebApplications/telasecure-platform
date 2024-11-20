using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;

public class WarehouseCommandService (
    IWarehouseRepository warehouseRepository,
    IUnitOfWork unitOfWork)
: IWarehouseCommandService
{
    public async Task<Warehouse?> Handle(CreateWarehouseCommand command)
    {
        var warehouse = new Warehouse(command);
        try
        {
            await warehouseRepository.AddAsync(warehouse);
            await unitOfWork.CompleteAsync();
            return warehouse;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    
    public async Task<Warehouse?> Handle(UpdateWarehouseCommand command)
    {
        var warehouse = await warehouseRepository.FindByIdAsync(command.WarehouseId);
        if (warehouse == null) return null;
        try
        {
            warehouse.UpdateInformation(command.Name, command.Location, command.Description, command.Capacity, command.Contact, command.Temperature, command.Humidity);
            warehouseRepository.Update(warehouse);
            await unitOfWork.CompleteAsync();
            return warehouse;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    public async Task<bool> Handle(DeleteWarehouseCommand command)
    {
        try
        {
            var warehouse = await warehouseRepository.FindByIdAsync(command.WarehouseId);
            if (warehouse == null) return false;

            warehouseRepository.Remove(warehouse);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
}