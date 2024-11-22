using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class UpdateSuggestionCommandFromResourceAssembler
{
    public static UpdateSuggestionCommand ToCommandFromResource(int categoryId, int suggestionId, CreateSuggestionResource resource)
    {
        return new UpdateSuggestionCommand(categoryId, suggestionId, resource.Description);
    }
}