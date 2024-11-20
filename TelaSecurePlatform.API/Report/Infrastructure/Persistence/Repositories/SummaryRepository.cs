using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using TelaSecurePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TelaSecurePlatform.API.Reports.Infrastructure.Persistence.Repositories
{
    public class SummaryRepository : BaseRepository<Report.Domain.Model.Aggregates.Summary>, ISummaryRepository
    {
        public SummaryRepository(AppDbContext context) : base(context)
        {
        }

        public new async Task<Report.Domain.Model.Aggregates.Summary?> FindByIdAsync(int id) =>
            await Context.Set<Report.Domain.Model.Aggregates.Summary>()
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

        public new async Task<IEnumerable<Report.Domain.Model.Aggregates.Summary>> ListAsync() =>
            await Context.Set<Report.Domain.Model.Aggregates.Summary>().ToListAsync();
    }
}