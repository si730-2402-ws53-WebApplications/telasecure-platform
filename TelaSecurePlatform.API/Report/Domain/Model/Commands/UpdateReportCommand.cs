using TelaSecurePlatform.API.Report.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Report.Domain.Model.Commands;

public record UpdateReportCommand(int Id, DateTime Date, List<FabricData> FabricsData, List<EnviroDeviceData> EnviroDevicesData, List<ClimateSensorData> ClimateSensorsData);
