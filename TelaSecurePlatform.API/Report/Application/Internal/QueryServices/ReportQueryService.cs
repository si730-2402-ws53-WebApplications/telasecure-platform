using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Domain.Model.Queries;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Report.Domain.Services;

namespace TelaSecurePlatform.API.Report.Application.Internal.QueryServices;

public class ReportQueryService(IReportRepository reportRepository) : IReportQueryService
{
    public async Task<Report?> Handle(GetReportByIdQuery query)
    {
        return await reportRepository.FindByIdAsync(query.ReportId);
    }

    public async Task<IEnumerable<Report>> Handle(GetAllReportsQuery query)
    {
        return await reportRepository.ListAsync();
    }
}