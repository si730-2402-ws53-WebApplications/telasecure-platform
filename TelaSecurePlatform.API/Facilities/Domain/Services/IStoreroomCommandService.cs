using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IStoreroomCommandService
{
    Task<Storeroom?> Handle(CreateStoreroomCommand command); 
    Task<Storeroom?> Handle(UpdateStoreroomCommand command);
    Task<bool> Handle(DeleteStoreroomCommand command);
}