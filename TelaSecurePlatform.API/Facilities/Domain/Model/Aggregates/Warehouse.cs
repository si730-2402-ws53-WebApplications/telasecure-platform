using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Aggregates;

public class Warehouse
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Location { get; private set; }
    public string Description { get; private set; }
    public int Capacity { get; private set; }
    public Contact Contact { get; private set; }
    public Temperature Temperature { get; private set; }
    public Humidity Humidity { get; private set; }
    
    
    public string Phone => Contact.Phone;
    public string Email => Contact.Email;
    
    public int ActualTemperature => Temperature.Actual;
    public int MaximumTemperature => Temperature.Maximum;
    public int MinimumTemperature => Temperature.Minimum;
    public string TemperatureUnit => Temperature.Unit;
    
    public int ActualHumidity => Humidity.Actual;
    public int MaximumHumidity => Humidity.Maximum;
    public int MinimumHumidity => Humidity.Minimum;
    public string HumidityUnit => Humidity.Unit;
    
    public Warehouse()
    {
        Contact = new Contact();
        Temperature = new Temperature();
        Humidity = new Humidity();
                
    }
    
    public Warehouse(string name, string location, string description, int capacity, string phone, string email, int actualTemperature, int maximumTemperature, int minimumTemperature, string temperatureUnit, int actualHumidity, int maximumHumidity, int minimumHumidity, string humidityUnit)
    {
        Name = name;
        Location = location;
        Description = description;
        Capacity = capacity;
        Contact = new Contact(phone, email);
        Temperature = new Temperature(actualTemperature, maximumTemperature, minimumTemperature, temperatureUnit);
        Humidity = new Humidity(actualHumidity, maximumHumidity, minimumHumidity, humidityUnit);
    }

    public Warehouse(CreateWarehouseCommand command)
    {
        Name = command.Name;
        Location = command.Location;
        Description = command.Description;
        Capacity = command.Capacity;
        Contact = new Contact(command.Phone, command.Email);
        Temperature = new Temperature(command.ActualTemperature, command.MaximumTemperature, command.MinimumTemperature, command.TemperatureUnit);
        Humidity = new Humidity(command.ActualHumidity, command.MaximumHumidity, command.MinimumHumidity, command.HumidityUnit);
    }
    
    public void UpdateInformation(string name, string location, string description, int capacity, Contact contact, Temperature temperature, Humidity humidity)
    {
        Name = name;
        Location = location;
        Description = description;
        Capacity = capacity;
        Contact = contact;
        Temperature = temperature;
        Humidity = humidity;
    }
}