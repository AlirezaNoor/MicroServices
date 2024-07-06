using IdentityService.Application.Services;
using IdentityService.ApplicationContract.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Application.DependecyInjection;

public static class UserServiceDependecy
{
    public static void UsermethodDependecy( this IServiceCollection services)
    {
        services.AddScoped<IUserServices, UserServices>();
    }
}