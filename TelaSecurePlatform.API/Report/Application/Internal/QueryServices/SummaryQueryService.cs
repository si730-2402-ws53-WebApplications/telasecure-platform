using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Domain.Model.Queries;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Report.Domain.Services;

namespace TelaSecurePlatform.API.Report.Application.Internal.QueryServices;

public class SummaryQueryService(ISummaryRepository summaryRepository) : ISummaryQueryService
{
    public async Task<Domain.Model.Aggregates.Summary?> Handle(GetSummaryByIdQuery query)
    {
        return await summaryRepository.FindByIdAsync(query.SummaryId);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Summary>> Handle(GetAllSummariesQuery query)
    {
        return await summaryRepository.ListAsync();
    }
}