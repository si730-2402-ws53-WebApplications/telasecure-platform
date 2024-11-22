using TelaSecurePlatform.API.Inventory.Domain.Model.Commands;
using TelaSecurePlatform.API.Inventory.Domain.Model.Entities;

namespace TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;

public class Category
{
    public int Id { get; }
    public string Name { get; private set; }
    public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    
    public Category()
    {
        Name = string.Empty;
    }
    
    public Category(string name)
    {
        Name = name;
    }

    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }
    
    public void UpdateInformation(string name)
    {
        Name = name;
    }
    
    public void AddSuggestion(Suggestion suggestion)
    {
        Suggestions.Add(suggestion);
    }
}