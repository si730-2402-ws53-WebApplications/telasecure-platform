using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Report.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Transform;

public static class SummaryResourceFromEntityAssembler
{
    public static SummaryResource ToResourceFromEntity(TelaSecurePlatform.API.Report.Domain.Model.Aggregates.Summary entity)
    {
        return new SummaryResource(
            entity.Id,
            entity.Date,
            entity.FabricsData,
            entity.EnviroDevicesData,
            entity.ClimateSensorsData
        );
    }
}