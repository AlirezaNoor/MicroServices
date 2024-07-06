using CatalogService.Domain.Base;

namespace CatalogService.Domain.Product;

public class Products:AggregateRoot<ProductId>
{
    public string Name { get; set; }
    public double price { get; set; }
    public string Description { get; set; }


    public Products createProduct(string name , double price ,string Description)
    {
        var id = new ProductId(Guid.NewGuid());
        return new Products(id, name, price, Description);
    }
    
    
    
    
    protected Products()
    {
        
    }

    public Products(ProductId id,string name, double price, string description)
    {
        Id = id;
        Name = name;
        this.price = price;
        Description = description;
    }
}