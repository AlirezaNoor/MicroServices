using IdentityService.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentiyService.Infrustructure.Configuration;

public class UserConfiguration:IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
        x=>x.Value,
        x=>new UserId(x)
            );
    }
    
}