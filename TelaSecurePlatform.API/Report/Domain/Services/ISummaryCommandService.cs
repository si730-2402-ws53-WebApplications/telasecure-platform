using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Report.Domain.Services;

public interface ISummaryCommandService
{
    Task<Model.Aggregates.Summary?> Handle(CreateSummaryCommand command);
    Task<Model.Aggregates.Summary?> Handle(UpdateSummaryCommand command);
    Task<bool> Handle(DeleteSummaryCommand command);
}