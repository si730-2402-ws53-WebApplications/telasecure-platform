using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Domain.Repositories;
using TelaSecurePlatform.API.Shared.Domain.Repositories;
using TelaSecurePlatform.API.Report.Domain.Services;

namespace TelaSecurePlatform.API.Report.Application.Internal.CommandServices;

public class SummaryCommandService(
    ISummaryRepository summaryRepository,
    IUnitOfWork unitOfWork)
    : ISummaryCommandService
{
    public async Task<Domain.Model.Aggregates.Summary?> Handle(CreateSummaryCommand command)
    {
        var summary = new Domain.Model.Aggregates.Summary(command.Id, command.Date, command.FabricsData, command.EnviroDevicesData, command.ClimateSensorsData);
        await summaryRepository.AddAsync(summary);
        await unitOfWork.CompleteAsync();
        return summary;
    }

    public async Task<Domain.Model.Aggregates.Summary?> Handle(UpdateSummaryCommand command)
    {
        var summary = await summaryRepository.FindByIdAsync(command.Id);
        if (summary == null)
        {
            return null;
        }
        summary.UpdateInformation(command.Date, command.FabricsData, command.EnviroDevicesData, command.ClimateSensorsData);
        await unitOfWork.CompleteAsync();
        return summary;
    }

    public async Task<bool> Handle(DeleteSummaryCommand command)
    {
        var summary = await summaryRepository.FindByIdAsync(command.SummaryId);
        if (summary == null)
        {
            return false;
        }
        summaryRepository.Remove(summary);
        await unitOfWork.CompleteAsync();
        return true;
    }
}