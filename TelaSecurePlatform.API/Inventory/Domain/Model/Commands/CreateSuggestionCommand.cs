using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Inventory.Domain.Model.Commands;

public record CreateSuggestionCommand(int CategoryId, string Description, Category Category);