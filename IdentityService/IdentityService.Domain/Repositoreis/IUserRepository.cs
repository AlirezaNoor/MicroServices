using IdentityService.Domain.User;

namespace IdentityService.Domain.Repositoreis;

public interface IUserRepository
{
    Task<Users> GetByIdAsync(string id);
    Task<Users> GetByUsernameAsync(string username);
    Task AddAsync(Users user);
}