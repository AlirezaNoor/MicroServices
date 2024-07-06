using IdentityService.ApplicationContract.Dto.user;

namespace IdentityService.Domain.Extensions;

public interface ITokenProvider
{
    Task<string> TokenGenator(loginUser login);
}