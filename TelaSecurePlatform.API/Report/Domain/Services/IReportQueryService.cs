using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Report.Domain.Services;

public interface IReportQueryService
{
    Task<Report?> Handle(GetReportByIdQuery query);
    Task<IEnumerable<Report>> Handle(GetAllReportsQuery query);
}