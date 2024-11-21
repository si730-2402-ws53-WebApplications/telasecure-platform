using System.ComponentModel.DataAnnotations;

namespace TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

public class ClimateSensorData
{
    public int Id { get; set; }
    public string SensorType { get; set; }
    public double Value { get; set; }
    public int SummaryId { get; set; }
    public Summary Summary { get; set; }
}
