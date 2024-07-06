using IdentityService.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace IdentiyService.Infrustructure.Context;

public class IdentityContext:DbContext
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);

    }

    public DbSet<Users> user { get; set; }
}