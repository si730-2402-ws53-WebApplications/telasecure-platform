using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;

public class ClimateSensor
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }
    public string StoreRoomId { get; private set; }
    
    public ClimateSensor()
    {
    }
    
    public ClimateSensor(string name, string model, string type, string image, string storeRoomId)
    {
        Name = name;
        Model = model;
        Type = type;
        Image = image;
        StoreRoomId = storeRoomId;
    }

    public ClimateSensor(CreateClimateSensorCommand command)
    {
        Name = command.Name;
        Model = command.Model;
        Type = command.Type;
        Image = command.Image;
        StoreRoomId = command.StoreroomId;
    }
}