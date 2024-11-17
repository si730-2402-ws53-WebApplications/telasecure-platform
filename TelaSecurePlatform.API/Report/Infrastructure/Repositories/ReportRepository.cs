/*

using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Reports.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Reports.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TelaSecurePlatform.API.Reports.Infrastructure.Persistence.Repositories;

public class ReportRepository(AppDbContext context) : BaseRepository<Report>(context), IReportRepository
{
    public new async Task<Report?> FindByIdAsync(int id) =>
        await Context.Set<Report>()
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();

    public new async Task<IEnumerable<Report>> ListAsync() =>
        await Context.Set<Report>().ToListAsync();
}

*/