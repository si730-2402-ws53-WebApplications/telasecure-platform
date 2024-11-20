using TelaSecurePlatform.API.Report.Domain.Model.Commands;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

public static class CreateSummaryCommandFromResourceAssembler
{
    public static CreateSummaryCommand ToCommandFromResource(CreateSummaryResource resource)
    {
        return new CreateSummaryCommand(resource.Date, resource.FabricsData, resource.EnviroDevicesData, resource.ClimateSensorsData);
    }
}