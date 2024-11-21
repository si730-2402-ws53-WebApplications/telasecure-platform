using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

/*namespace TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

public class Summary
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    
    [NotMapped]
    public List<ClimateSensorData> ClimateSensorsData { get; set; }
    public List<FabricData> FabricsData { get; private set; }
    public List<EnviroDeviceData> EnviroDevicesData { get; private set; }

    public Summary(int id, DateTime date, List<FabricData> fabricsData, List<EnviroDeviceData> enviroDevicesData, List<ClimateSensorData> climateSensorsData)
    {
        Id = id;
        Date = date;
        FabricsData = fabricsData;
        EnviroDevicesData = enviroDevicesData;
        ClimateSensorsData = climateSensorsData;
    }

    public void UpdateInformation(DateTime date, List<FabricData> fabricsData, List<EnviroDeviceData> enviroDevicesData, List<ClimateSensorData> climateSensorsData)
    {
        Date = date;
        FabricsData = fabricsData;
        EnviroDevicesData = enviroDevicesData;
        ClimateSensorsData = climateSensorsData;
    }
}*/