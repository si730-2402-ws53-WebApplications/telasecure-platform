using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Report.Interfaces.REST.Resources;

public record CreateReportResource(DateTime Date, List<FabricData> FabricsData, List<EnviroDeviceData> EnviroDevicesData, List<ClimateSensorData> ClimateSensorsData);
