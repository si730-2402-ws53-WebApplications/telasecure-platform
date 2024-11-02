using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IClimateSensorQueryService
{
    Task<IEnumerable<ClimateSensor>> Handle(GetAllClimateSensorsQuery query);

    Task<ClimateSensor?> Handle(GetClimateSensorByIdQuery query);
}