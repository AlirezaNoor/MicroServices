using Grpc.Core;
using IdentiyService.Protos;

namespace Identity.API.GrpcServices
{
    public class PermissionService : Permission.PermissionBase
    {
        public override async Task<CheckPermissionResponse> CheckPermission(CheckPermissionRequest request, ServerCallContext context)
        {
            var temp = context.AuthContext.ToString();
            var response = new CheckPermissionResponse();
            //call business service
            if (request.Permission == "product_get_all" && request.Applicationid == "catalog")
            {
                response.Allowed = true;
            }
            else
            {
                response.Allowed = false;
            }
            return await Task.FromResult(response);
        }
    }
}
