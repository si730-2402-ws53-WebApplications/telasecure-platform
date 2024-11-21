using System.Text.Json;
using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace TelaSecurePlatform.API.Report.Infrastructure;

public class ClimateSensorDataListConverter : ValueConverter<List<ClimateSensorData>, string>
{
    public ClimateSensorDataListConverter() : base(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<List<ClimateSensorData>>(v))
    {
    }
}