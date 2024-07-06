using IdentityService.Domain.Extensions;
using IdentityService.Domain.Repositoreis;
using IdentiyService.Infrustructure.Context;
using IdentiyService.Infrustructure.Extensions;
using IdentiyService.Infrustructure.Repositores;
using IdentiyService.Infrustructure.Unitofwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentiyService.Infrustructure.DependecyEnjection;

public static class DependecyEnjections
{
    public static void  DependecyEnjectionsMethod(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<IdentityContext>
            (x=>x.UseNpgsql(configuration.GetConnectionString("Identity")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfwork, UnitOfwork>();
        services.AddScoped<ITokenProvider, TokenProvider>();
    }
}