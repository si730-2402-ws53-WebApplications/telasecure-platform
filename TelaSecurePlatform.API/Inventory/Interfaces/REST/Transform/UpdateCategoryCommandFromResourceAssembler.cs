using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Inventory.Interfaces.REST.Transform;

public class UpdateCategoryCommandFromResourceAssembler
{
    public static UpdateCategoryCommand ToCommandFromResource(int categoryId, UpdateCategoryResource resource)
    {
        return new UpdateCategoryCommand(categoryId, resource.Name);
    }
}