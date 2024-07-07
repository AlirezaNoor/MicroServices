using IdentityService.ApplicationContract.Dto.user;
using IdentityService.ApplicationContract.UserServices;
using IdentityService.Domain.Extensions;
using IdentityService.Domain.Repositoreis;
using IdentityService.Domain.User;
using IdentityServices.Common.Responce;
using IdentiyService.Infrustructure.Unitofwork;

namespace IdentityService.Application.Services;

public class UserServices:IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfwork _unitOfwork;
    private readonly ITokenProvider _tokenProvider;

    public UserServices(IUserRepository userRepository, IUnitOfwork unitOfwork, ITokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _unitOfwork = unitOfwork;
        _tokenProvider = tokenProvider;
    }

    public async Task<BaseResponse<UserDto>> Regestration(CreateUserDto createUserDto)
    {
        var user = new Users();
        var hashedpassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.password);
        var test=user.Create(createUserDto.name, createUserDto.username, hashedpassword);
        await _userRepository.AddAsync(test);
        await _unitOfwork.saveCahges();
        return new BaseResponse<UserDto>()
        {
            Message = "User Created Successfully",
            IsSuccess = true
        };
    }

    public async Task<BaseResponse<UserDto>> Login(loginUser login)
    {
        var user = await _userRepository.GetByUsernameAsync(login.username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(login.password, user.Password))
        {
            return new BaseResponse<UserDto>()
            {
                Message = "UnAthourized user!",
                IsSuccess = false

            };
        }

        var token = await _tokenProvider.TokenGenator(login, user.Id.Value.ToString());

        
        return new BaseResponse<UserDto>()
        {
            Message = " Athourized user!",
            IsSuccess = true,
            Response =  new UserDto()
            {
                username = login.username,
                Token = token
            }
        };
    }
}