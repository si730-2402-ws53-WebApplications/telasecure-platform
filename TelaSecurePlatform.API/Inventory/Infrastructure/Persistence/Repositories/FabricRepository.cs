using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TelaSecurePlatform.API.Inventory.Infrastructure.Persistence.Repositories;

public class FabricRepository(AppDbContext context) : BaseRepository<Fabric>(context), IFabricRepository
{
    public async Task<IEnumerable<Fabric>> FindByCategoryIdAsync(int categoryId) =>
        await Context.Set<Fabric>()
            .Where(f => f.CategoryId == categoryId)
            .ToListAsync();
    
    public new async Task<Fabric?> FindByIdAsync(int id) =>
        await Context.Set<Fabric>()
            .Where(f => f.Id == id)
            .FirstOrDefaultAsync();
    
    public new async Task<IEnumerable<Fabric>> ListAsync() =>
        await Context.Set<Fabric>().ToListAsync();
    
}