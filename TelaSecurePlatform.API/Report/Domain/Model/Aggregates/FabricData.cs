using System.ComponentModel.DataAnnotations;

namespace TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

public class FabricData
{
    public int Id { get; set; }

    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty; 

    public int Quantity { get; set; }
}