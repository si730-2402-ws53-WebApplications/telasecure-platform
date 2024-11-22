using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;
using TelaSecurePlatform.API.Inventory.Domain.Model.Queries;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.QueryServices;

public class CategoryQueryService(ICategoryRepository categoryRepository): ICategoryQueryService
{
    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.CategoryId);
    }
    
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Suggestion>> Handle(GetAllSuggestionsByCategoryId query)
    {
        var category = await categoryRepository.FindByIdAsync(query.CategoryId);
        return category?.Suggestions ?? Enumerable.Empty<Suggestion>();
    }
}