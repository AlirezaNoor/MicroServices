using IdentityService.Domain.Base;

namespace IdentityService.Domain.User;

public class UserId:StronglyTypedId<UserId>
{
    public UserId(Guid value) : base(value)
    {
    }
}