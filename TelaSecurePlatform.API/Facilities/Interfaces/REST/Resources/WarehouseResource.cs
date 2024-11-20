using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

public record WarehouseResource(int Id, string Name, string Location, string Description, int Capacity, Contact Contact, Temperature Temperature, Humidity Humidity);