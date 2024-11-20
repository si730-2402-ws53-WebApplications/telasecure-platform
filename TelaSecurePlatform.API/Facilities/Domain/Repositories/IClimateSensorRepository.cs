using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Facilities.Domain.Repositories;

public interface IClimateSensorRepository : IBaseRepository<ClimateSensor>
{
    //constain para no crear si tiene el mismo nombre en el mismo almacen
    Task<bool> FindByNameAndWarehouseIdAsync(string name, string warehouseId);
}