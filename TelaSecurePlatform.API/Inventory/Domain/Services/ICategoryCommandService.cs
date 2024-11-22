using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;

namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category?> Handle(UpdateCategoryCommand command);
    Task<bool> Handle(DeleteCategoryCommand command);
    
    Task<Suggestion?> Handle(CreateSuggestionCommand command);
    Task<Suggestion?> Handle(UpdateSuggestionCommand command);
    Task<bool> Handle(DeleteSuggestionCommand command);
}