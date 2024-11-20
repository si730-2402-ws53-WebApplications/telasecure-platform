using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IWarehouseCommandService
{
    Task<Warehouse?> Handle(CreateWarehouseCommand command); 
    Task<Warehouse?> Handle(UpdateWarehouseCommand command);
    Task<bool> Handle(DeleteWarehouseCommand command);
}