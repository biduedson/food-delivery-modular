using BuildingBlocks.Abstractions.CQRS.Event.Internal;
using BuildingBlocks.Abstractions.Domain;

namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um armazenamento para eventos de domínio de agregados durante uma requisição.
/// </summary>
public interface IAggregatesDomainEventsRequestStore
{
    /// <summary>
    /// Adiciona os eventos de um agregado ao armazenamento.
    /// </summary>
    /// <typeparam name="T">O tipo do agregado.</typeparam>
    /// <param name="aggregate">O agregado do qual os eventos serão extraídos.</param>
    /// <returns>A lista de eventos de domínio adicionados.</returns>
    IReadOnlyList<IDomainEvent> AddEventsFromAggregate<T>(T aggregate)
        where T : IHaveAggregate;

    /// <summary>
    /// Adiciona uma lista de eventos de domínio ao armazenamento.
    /// </summary>
    /// <param name="events">Os eventos a serem adicionados.</param>
    void AddEvents(IReadOnlyList<IDomainEvent> events);

    /// <summary>
    /// Obtém todos os eventos de domínio não confirmados do armazenamento.
    /// </summary>
    /// <returns>Uma lista de eventos de domínio não confirmados.</returns>
    IReadOnlyList<IDomainEvent> GetAllUncommittedEvents();
}
