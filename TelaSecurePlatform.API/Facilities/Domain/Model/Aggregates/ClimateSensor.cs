using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;

public class ClimateSensor
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public EClimateSensorType Type { get; private set; }
    public string Image { get; private set; }
    public string WarehouseId { get; private set; }
    
    public ClimateSensor()
    {
    }
    
    public ClimateSensor(string name, string model, EClimateSensorType type, string image, string warehouseId)
    {
        Name = name;
        Model = model;
        Type = type;
        Image = image;
        WarehouseId = warehouseId;
    }

    public ClimateSensor(CreateClimateSensorCommand command)
    {
        Name = command.Name;
        Model = command.Model;
        Type = command.Type;
        Image = command.Image;
        WarehouseId = command.WarehouseId;
    }
    
    public void UpdateInformation(string name, string model, EClimateSensorType type, string image, string warehouseId)
    {
        Name = name;
        Model = model;
        Type = type;
        Image = image;
        WarehouseId = warehouseId;
    }
}