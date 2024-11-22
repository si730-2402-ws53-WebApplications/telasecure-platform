using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class SuggestionResourceFromEntityAssembler
{
    public static SuggestionResource ToResourceFromEntity(Suggestion suggestion)
    {
        return new SuggestionResource(suggestion.Id, suggestion.description);
    }
}