using CatalogService.Domain.Events;

namespace CatalogService.Domain.Base;

public interface IAggregateRoot
{
    IReadOnlyCollection<IEvent> DomainEvents { get; }
    void ClearDomainEvents();
}