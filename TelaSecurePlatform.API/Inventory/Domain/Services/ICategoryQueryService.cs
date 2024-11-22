using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;
using TelaSecurePlatform.API.Inventory.Domain.Model.Queries;

namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface ICategoryQueryService 
{
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
    
    Task<IEnumerable<Suggestion>> Handle(GetAllSuggestionsByCategoryId query);
    //se puede agregar un get suggestion by id and category id
}