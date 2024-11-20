using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;
using TelaSecurePlatform.API.Report.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

public static class UpdateReportCommandFromResourceAssembler
{
    public static UpdateReportCommand ToCommand(int reportId, UpdateReportResource resource)
    {
        return new UpdateReportCommand(reportId, resource.Date, resource.FabricsData, resource.EnviroDevicesData, resource.ClimateSensorsData);
    }
}