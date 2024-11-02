using TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Services;

public interface IClimateSensorCommandService
{
    Task<ClimateSensor?> Handle(CreateClimateSensorCommand command);
}