namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um processador para publicar e despachar eventos.
/// </summary>
public interface IEventProcessor
{
    /// <summary>
    /// Publica um evento para processamento externo (ex: outbox, message broker).
    /// </summary>
    /// <typeparam name="TEvent">O tipo do evento.</typeparam>
    /// <param name="event">O evento a ser publicado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    /// <summary>
    /// Publica uma lista de eventos para processamento externo.
    /// </summary>
    /// <typeparam name="TEvent">O tipo do evento.</typeparam>
    /// <param name="events">Os eventos a serem publicados.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync<TEvent>(TEvent[] events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    /// <summary>
    /// Despacha um evento para manipuladores internos.
    /// </summary>
    /// <typeparam name="TEvent">O tipo do evento.</typeparam>
    /// <param name="event">O evento a ser despachado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task DispatchAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : IEvent;

    /// <summary>
    /// Despacha uma lista de eventos para manipuladores internos.
    /// </summary>
    /// <typeparam name="TEvent">O tipo do evento.</typeparam>
    /// <param name="events">Os eventos a serem despachados.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task DispatchAsync<TEvent>(TEvent[] events, CancellationToken cancellationToken = default)
        where TEvent : IEvent;
}
