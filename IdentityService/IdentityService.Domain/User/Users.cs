using IdentityService.Domain.Base;

namespace IdentityService.Domain.User;

public class Users:AggregateRoot<UserId>
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }



    public Users Create(string Name, string UserName, string Password)
    {
        var Id = new UserId(Guid.NewGuid());
        return new Users(Id,Name,UserName,Password);
    }
    
    public Users()
    {
    }

    protected Users(UserId id,string name, string userName, string password)
    {
        Id = id;
        Name = name;
        UserName = userName;
        Password = password;
    }
}