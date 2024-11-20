using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Domain.Repositories;
using TelaSecurePlatform.API.Report.Domain.Services;

namespace TelaSecurePlatform.API.Report.Application.Internal.CommandServices;

public class ReportCommandService(
    IReportRepository reportRepository,
    IUnitOfWork unitOfWork)
    : IReportCommandService
{
    public async Task<Report?> Handle(CreateReportCommand command)
    {
        var report = new Report(command.Date, command.FabricsData, command.EnviroDevicesData, command.ClimateSensorsData);
        await reportRepository.AddAsync(report);
        await unitOfWork.CompleteAsync();
        return report;
    }

    public async Task<Report?> Handle(UpdateReportCommand command)
    {
        var report = await reportRepository.FindByIdAsync(command.Id);
        if (report == null)
        {
            return null;
        }
        report.UpdateInformation(command.Date, command.FabricsData, command.EnviroDevicesData, command.ClimateSensorsData);
        await unitOfWork.CompleteAsync();
        return report;
    }

    public async Task<bool> Handle(DeleteReportCommand command)
    {
        var report = await reportRepository.FindByIdAsync(command.ReportId);
        if (report == null)
        {
            return false;
        }
        reportRepository.Remove(report);
        await unitOfWork.CompleteAsync();
        return true;
    }
}