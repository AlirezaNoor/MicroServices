using IdentiyService.Infrustructure.Context;

namespace IdentiyService.Infrustructure.Unitofwork;

public class UnitOfwork:IUnitOfwork
{

    private readonly IdentityContext _identityContext;

    public UnitOfwork(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task saveCahges()
    {

        await _identityContext.SaveChangesAsync();
    }
}