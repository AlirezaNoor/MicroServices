using CatalogService.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Contexts;

public class CatalogContext:DbContext
{
    public CatalogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Products> products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}