using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

public static class ReportResourceFromEntityAssembler
{
    public static ReportResource ToResourceFromEntity(Report entity)
    {
        return new ReportResource(
            entity.Id,
            entity.Date,
            entity.FabricsData,
            entity.EnviroDevicesData,
            entity.ClimateSensorsData
        );
    }
}