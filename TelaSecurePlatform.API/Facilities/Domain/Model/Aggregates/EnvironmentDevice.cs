using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;

public class EnvironmentDevice
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public int Value { get; private set; }
    public EEnvironmentDeviceType Type { get; private set; }
    public string Unit { get; private set; }
    public string WarehouseId { get; private set; }
    
    public EnvironmentDevice()
    {
    }
    
    public EnvironmentDevice(string name, string model, int value, EEnvironmentDeviceType type, string unit, string warehouseId)
    {
        Name = name;
        Model = model;
        Value = value;
        Type = type;
        Unit = unit;
        WarehouseId = warehouseId;
    }

    public EnvironmentDevice(CreateEnvironmentDeviceCommand command)
    {
        Name = command.Name;
        Model = command.Model;
        Value = command.Value;
        Type = command.Type;
        Unit = command.Unit;
        WarehouseId = command.WarehouseId;
    }
    
    public void UpdateInformation(string name, string model, int value, EEnvironmentDeviceType type, string unit, string warehouseId)
    {
        Name = name;
        Model = model;
        Value = value;
        Type = type;
        Unit = unit;
        WarehouseId = warehouseId;
    }
}