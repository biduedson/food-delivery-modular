using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um acessor para obter eventos de domínio não confirmados.
/// </summary>
public interface IDomainEventsAccessor
{
    /// <summary>
    /// Obtém todos os eventos de domínio que ainda não foram confirmados.
    /// </summary>
    IReadOnlyList<IDomainEvent> UnCommittedDomainEvents { get; }
}
