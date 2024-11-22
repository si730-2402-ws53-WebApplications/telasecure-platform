using Microsoft.EntityFrameworkCore;
using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;
using TelaSecurePlatform.API.Inventory.Domain.Repositories;
using TelaSecurePlatform.API.Inventory.Domain.Services;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Inventory.Application.Internal.CommandServices;

public class CategoryCommandService(ICategoryRepository categoryRepository
, IUnitOfWork unitOfWork) : ICategoryCommandService
{
    public async Task<Category?> Handle(CreateCategoryCommand command)
    {
        var category = new Category(command.Name);
        await categoryRepository.AddAsync(category);
        await unitOfWork.CompleteAsync();
        return category;
    }
    
    public async Task<Category?> Handle(UpdateCategoryCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.Id);
        if (category == null)
        {
            return null;
        }
        category.UpdateInformation(command.Name);
        await unitOfWork.CompleteAsync();
        return category;
    }
    
    public async Task<bool> Handle(DeleteCategoryCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.Id);
        if (category == null)
        {
            return false;
        }
        categoryRepository.Remove(category);
        await unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<Suggestion?> Handle(CreateSuggestionCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if (category == null)
        {
            throw new InvalidOperationException();
        }
        var suggestion = new Suggestion(command.Description, category);
        category.AddSuggestion(suggestion);
        categoryRepository.Update(category);
        
        await unitOfWork.CompleteAsync();
        return suggestion;
    }
    
    public async Task<Suggestion?> Handle(UpdateSuggestionCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if (category == null)
        {
            throw new InvalidOperationException();
        }
        var suggestion = category.Suggestions.FirstOrDefault(s => s.Id == command.SuggestionId);
        if (suggestion == null)
        {
            return null;
        }
        suggestion.UpdateInformation(command.Description);
        await unitOfWork.CompleteAsync();
        return suggestion;
    }
    
    public async Task<bool> Handle(DeleteSuggestionCommand command)
    {
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        if (category == null)
        {
            return false;
        }
        var suggestion = category.Suggestions.FirstOrDefault(s => s.Id == command.SuggestionId);
        if (suggestion == null)
        {
            return false;
        }
        category.Suggestions.Remove(suggestion);
        await unitOfWork.CompleteAsync();
        return true;
    }
}