/*

using TelaSecurePlatform.API.Reports.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Reports.Domain.Model.Commands;
using TelaSecurePlatform.API.Reports.Domain.Repositories;
using TelaSecurePlatform.API.Reports.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Reports.Application.Internal.CommandServices;

public class ReportCommandService(
    IReportRepository reportRepository,
    IUnitOfWork unitOfWork)
    : IReportCommandService
{
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        var report = new Report(command.Title, command.Content, command.AuthorId);
        await reportRepository.AddAsync(report);
        await unitOfWork.CompleteAsync();
        return report;
    }
}

*/