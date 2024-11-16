using TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

namespace TelaSecurePlatform.API.Facilities.Domain.Model.Commands;

public record UpdateStoreroomCommand(int StoreroomId, string Name, string Location, string Description, int Capacity, Contact Contact, Temperature Temperature, Humidity Humidity);