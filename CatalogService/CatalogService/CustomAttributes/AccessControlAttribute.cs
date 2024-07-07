 
using System.IdentityModel.Tokens.Jwt;
using CatalogService.Protos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogService.CustomAttributes
{
    public class AccessControlAttribute : ActionFilterAttribute
    {
        public string Permission { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var tokenString = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(tokenString);
            var token = jsonToken as JwtSecurityToken;
            var userId = token?.Claims.First(claim => claim.Type == "userId").Value;

            var permissionClient = context.HttpContext.RequestServices.GetService<Permission.PermissionClient>();
            var permissionResult = permissionClient.CheckPermission(
              new CheckPermissionRequest { Applicationid = "catalog", Permission = Permission, Userid = userId }
             );

            if (!permissionResult.Allowed)
            {
                context.Result = new BadRequestObjectResult("not access in action");
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
