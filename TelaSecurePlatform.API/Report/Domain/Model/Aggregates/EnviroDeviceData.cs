using System.ComponentModel.DataAnnotations;

namespace TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

public class EnviroDeviceData
{
    public int Id { get; set; }

    [MaxLength(100)] 
    public string DeviceName { get; set; } = string.Empty; 

    [MaxLength(100)] 
    public string Status { get; set; } = string.Empty; 
}