using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TelaSecurePlatform.API.Facilities.Infrastructure.Persistence.EFC.Repositories;

public class ClimateSensorRepository(AppDbContext context) 
    : BaseRepository<ClimateSensor>(context), IClimateSensorRepository 
{
    //para constrain de creacion por nombre y almacen
    public async Task<bool> FindByNameAndWarehouseIdAsync(string name, string warehouseId) =>
        await Context.Set<ClimateSensor>()
            .AnyAsync(cs => cs.Name == name && cs.WarehouseId == warehouseId); 
}