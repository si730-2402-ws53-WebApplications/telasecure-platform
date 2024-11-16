using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Facilities.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Application.Internal.CommandServices;

public class StoreroomCommandService (
    IStoreroomRepository storeroomRepository,
    IUnitOfWork unitOfWork)
: IStoreroomCommandService
{
    public async Task<Storeroom?> Handle(CreateStoreroomCommand command)
    {
        var storeroom = new Storeroom(command);
        try
        {
            await storeroomRepository.AddAsync(storeroom);
            await unitOfWork.CompleteAsync();
            return storeroom;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //actualizar un storeroom
    public async Task<Storeroom?> Handle(UpdateStoreroomCommand command)
    {
        var storeroom = await storeroomRepository.FindByIdAsync(command.StoreroomId);
        if (storeroom == null) return null;
        try
        {
            storeroom.UpdateInformation(command.Name, command.Location, command.Description, command.Capacity, command.Contact, command.Temperature, command.Humidity);
            storeroomRepository.Update(storeroom);
            await unitOfWork.CompleteAsync();
            return storeroom;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    //eliminar un storeroom
    public async Task<bool> Handle(DeleteStoreroomCommand command)
    {
        try
        {
            var storeroom = await storeroomRepository.FindByIdAsync(command.StoreroomId);
            if (storeroom == null) return false;

            storeroomRepository.Remove(storeroom);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
}