using BuildingBlocks.Abstractions.CQRS.Event;

namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para um repositório genérico de eventos.
/// </summary>
/// <typeparam name="TContext">O tipo do contexto do banco de dados.</typeparam>
/// <typeparam name="TEvent">O tipo do evento.</typeparam>
public interface IEventRepository<TContext, TEvent>
    where TEvent : IEvent
{
    /// <summary>
    /// Insere um único evento de forma assíncrona.
    /// </summary>
    /// <param name="event">O evento a ser inserido.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task InsertEvent(TEvent @event, CancellationToken cancellationToken);

    /// <summary>
    /// Insere múltiplos eventos de forma assíncrona.
    /// </summary>
    /// <param name="events">A lista de eventos a ser inserida.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task InsertRangeEvent(List<TEvent> @events, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza um único evento de forma assíncrona.
    /// </summary>
    /// <param name="event">O evento a ser atualizado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task UpdateEvent(TEvent @event, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza múltiplos eventos de forma assíncrona.
    /// </summary>
    /// <param name="events">A lista de eventos a ser atualizada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task UpdateRangeEvent(List<TEvent> @events, CancellationToken cancellationToken);

    /// <summary>
    /// Deleta um único evento de forma assíncrona.
    /// </summary>
    /// <param name="event">O evento a ser deletado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteEvent(TEvent @event, CancellationToken cancellationToken);

    /// <summary>
    /// Deleta múltiplos eventos de forma assíncrona.
    /// </summary>
    /// <param name="events">A lista de eventos a ser deletada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteRangeEvent(List<TEvent> @events, CancellationToken cancellationToken);
}
