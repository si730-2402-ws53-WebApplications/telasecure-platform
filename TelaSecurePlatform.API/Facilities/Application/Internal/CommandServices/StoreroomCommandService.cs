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
}