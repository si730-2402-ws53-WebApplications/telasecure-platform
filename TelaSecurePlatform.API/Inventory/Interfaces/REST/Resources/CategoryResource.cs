namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

public record CategoryResource(int CategoryId, string Name, IEnumerable<SuggestionResource> Suggestions);