namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um contexto para gerenciar eventos de domínio não confirmados.
/// </summary>
public interface IDomainEventContext
{
    /// <summary>
    /// Obtém todos os eventos de domínio que ainda não foram confirmados.
    /// </summary>
    /// <returns>Uma lista de eventos de domínio não confirmados.</returns>
    IReadOnlyList<IDomainEvent> GetAllUncommittedEvents();

    /// <summary>
    /// Marca todos os eventos de domínio não confirmados como confirmados.
    /// </summary>
    void MarkUncommittedDomainEventAsCommitted();
}
