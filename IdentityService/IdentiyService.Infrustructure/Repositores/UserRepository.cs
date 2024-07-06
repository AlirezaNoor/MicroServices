using IdentityService.Domain.Repositoreis;
using IdentityService.Domain.User;
using IdentiyService.Infrustructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IdentiyService.Infrustructure.Repositores;

public class UserRepository : IUserRepository
{
    private readonly IdentityContext _identityContext;

    public UserRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<Users> GetByIdAsync(string id)
    {
        var result = await _identityContext.user.FirstOrDefaultAsync(x => x.Id.Equals(id));

        return result;
    }

    public async Task<Users> GetByUsernameAsync(string username)
    {
        var result = await _identityContext.user.FirstOrDefaultAsync(x => x.UserName.Equals(username));

        return result;
    }

    public async Task AddAsync(Users user)
    {
        var result = await _identityContext.user.AddAsync(user);
    }
}