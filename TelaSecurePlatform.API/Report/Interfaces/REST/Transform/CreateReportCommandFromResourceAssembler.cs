using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

public static class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource)
    {
        return new CreateReportCommand(resource.Date, resource.FabricsData, resource.EnviroDevicesData, resource.ClimateSensorsData);
    }
}