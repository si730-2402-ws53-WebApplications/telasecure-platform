using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;

public class EnviroDevice
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public int Value { get; private set; }
    public string Type { get; private set; }
    public string Unit { get; private set; }
    public string StoreRoomId { get; private set; }
    
    public EnviroDevice()
    {
    }
    
    public EnviroDevice(string name, string model, int value, string type, string unit, string storeRoomId)
    {
        Name = name;
        Model = model;
        Value = value;
        Type = type;
        Unit = unit;
        StoreRoomId = storeRoomId;
    }

    public EnviroDevice(CreateEnviroDeviceCommand command)
    {
        Name = command.Name;
        Model = command.Model;
        Value = command.Value;
        Type = command.Type;
        Unit = command.Unit;
        StoreRoomId = command.StoreRoomId;
    }
}