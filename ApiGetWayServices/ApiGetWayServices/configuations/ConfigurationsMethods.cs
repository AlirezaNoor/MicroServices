using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace IdentityService.Configuration;

public static class ConfigurationsMethods
{
    public static void JWTConfigration(this  IServiceCollection services, IConfiguration Configuration)
    {
        var authenticationProviderKey = "IdentityApiKey";
        var jwtSettings = Configuration.GetSection("Jwt");
        var secretKey = jwtSettings["Secret"];
        var key = Encoding.ASCII.GetBytes(secretKey);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(authenticationProviderKey,x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

    }
}