/*

using TelaSecurePlatform.API.Reports.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Reports.Domain.Model.Queries;
using TelaSecurePlatform.API.Reports.Domain.Repositories;
using TelaSecurePlatform.API.Reports.Domain.Services;

namespace TelaSecurePlatform.API.Reports.Application.Internal.QueryServices;

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

*/