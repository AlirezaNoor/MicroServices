using IdentityService.ApplicationContract.Dto.user;
using IdentityService.ApplicationContract.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserServices _userServices;

    public AuthController(IUserServices userServices)
    {
        _userServices = userServices;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserDto createUserDto)
    {
         var result=await _userServices.Regestration(createUserDto);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(loginUser user )
    {
        var result = await _userServices.Login(user);

        return Ok(result);
    }
    
    [HttpGet("Check")]
    public async Task<string> CheckFortest( )
    {
        return "Its work";
    }
}