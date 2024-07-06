using IdentityService.ApplicationContract.Dto.user;
using IdentityServices.Common.Responce;

namespace IdentityService.ApplicationContract.UserServices;

public interface IUserServices
{
    Task<BaseResponse<UserDto>> Regestration(CreateUserDto createUserDto);
    Task<BaseResponse<UserDto>> Login(loginUser login);
}