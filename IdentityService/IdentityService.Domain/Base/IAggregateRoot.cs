using IdentityService.Domain.Events;

namespace IdentityService.Domain.Base;

public interface IAggregateRoot
{
    IReadOnlyCollection<IEvent> DomainEvents { get; }
    void ClearDomainEvents();
}