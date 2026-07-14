namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um evento de domínio, que representa algo que aconteceu no domínio.
/// </summary>
public interface IDomainEvent : IEvent
{
    /// <summary>
    /// O identificador do agregado ao qual o evento pertence.
    /// </summary>
    dynamic AggregateId { get; }

    /// <summary>
    /// O número de sequência do evento no agregado.
    /// </summary>
    long AggregateSequenceNumber { get; }

    /// <summary>
    /// Associa o evento a um agregado específico.
    /// </summary>
    /// <param name="aggregateId">O identificador do agregado.</param>
    /// <param name="version">A versão do agregado.</param>
    /// <returns>O evento de domínio com as informações do agregado.</returns>
    public IDomainEvent WithAggregate(dynamic aggregateId, long version);
}
