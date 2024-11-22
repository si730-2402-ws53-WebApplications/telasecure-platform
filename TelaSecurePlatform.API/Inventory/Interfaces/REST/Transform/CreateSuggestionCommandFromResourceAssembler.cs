using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class CreateSuggestionCommandFromResourceAssembler
{
    public static CreateSuggestionCommand ToCommandFromResource(int categoryId, CreateSuggestionResource resource, Category category)
    {
        return new CreateSuggestionCommand(categoryId, resource.Description, category);
    }
}