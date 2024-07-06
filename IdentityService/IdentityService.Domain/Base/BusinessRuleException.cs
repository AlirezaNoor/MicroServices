namespace IdentityService.Domain.Base;

public class BusinessRuleException:Exception
{
    public BusinessRuleException( string message ):base(message)
    {
        
    }
}