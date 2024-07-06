using CatalogService.Domain.Base;

namespace CatalogService.Domain.Product;

public class ProductId:StronglyTypedId<ProductId>
{
    public ProductId(Guid value) : base(value)
    {
    }
}