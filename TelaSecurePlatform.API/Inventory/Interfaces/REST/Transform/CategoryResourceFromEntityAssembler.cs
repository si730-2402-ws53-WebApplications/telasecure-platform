using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        var suggestionResources = entity.Suggestions.Select(s => new SuggestionResource(s.Id, s.description));
        return new CategoryResource(entity.Id, entity.Name, suggestionResources);
    }
}