using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}