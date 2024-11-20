namespace TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

public class Summary
{
    public int Id { get; }
    public DateTime Date { get; private set; }
    public List<FabricData> FabricsData { get; private set; }
    public List<EnviroDeviceData> EnviroDevicesData { get; private set; }
    public List<ClimateSensorData> ClimateSensorsData { get; private set; }

    public Summary(DateTime date, List<FabricData> fabricsData, List<EnviroDeviceData> enviroDevicesData, List<ClimateSensorData> climateSensorsData)
    {
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
}