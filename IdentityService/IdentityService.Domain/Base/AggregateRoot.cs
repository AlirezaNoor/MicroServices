using IdentityService.Domain.Events;

namespace IdentityService.Domain.Base;

public class AggregateRoot<TKey>:Entity<TKey>,IAggregateRoot
{
    public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(IEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<IEvent>();
        _domainEvents.Add(domainEvent);
        //publish
        //1 => get IMeditR from HttpContext

        //2 => Global Class Utility => Event Publish 


        //
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    private List<IEvent> _domainEvents;
}