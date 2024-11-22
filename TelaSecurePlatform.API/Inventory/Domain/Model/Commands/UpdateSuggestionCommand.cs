namespace TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

public record UpdateSuggestionCommand(int CategoryId, int SuggestionId, string Description);