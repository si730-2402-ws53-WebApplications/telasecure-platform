using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Report.Domain.Repositories;

public interface IReportRepository : IBaseRepository<Model.Aggregates.Report>
{
}