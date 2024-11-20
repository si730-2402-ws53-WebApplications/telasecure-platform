using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Report.Domain.Services;

public interface IReportCommandService
{
    Task<Report?> Handle(CreateReportCommand command);
    Task<Report?> Handle(UpdateReportCommand command);
    Task<bool> Handle(DeleteReportCommand command);
}