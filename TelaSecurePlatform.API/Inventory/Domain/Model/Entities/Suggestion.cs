using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;

namespace TelaSecurePlatform.API.Inventory.Domain.Model.Entities;

public class Suggestion
{
    public int Id { get;}
    public string description { get; private set; }
    public Category Category { get; private set; }
    public int CategoryId { get; private set; }
    public Suggestion() { }
    
    public Suggestion(string description, Category category )
    {
        this.description = description;
        Category = category;
        CategoryId = category.Id;
    }
    
    public void UpdateInformation(string description)
    {
        this.description = description;
    } 
}