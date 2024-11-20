namespace TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;

public class Fabric
{
    public int Id { get; }
    //public string Code { get; private set; }
    public string Name { get; private set; }
    public int WarehouseId { get; private set; }
    //public Category CategoryId { get; private set; }
    public int CategoryId { get; private set; }
    public int Quantity { get; private set; }
    
    public Fabric(string name, int warehouseId, int categoryId, int quantity)
    {
        Name = name;
        WarehouseId = warehouseId;
        CategoryId = categoryId;
        Quantity = quantity;
    }

    public void UpdateInformation(string name, int warehouseId, int categoryId, int quantity)
    {
        Name = name;
        WarehouseId = warehouseId;
        CategoryId = categoryId;
        Quantity = quantity;
    }
}
                   