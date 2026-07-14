using BuildingBlocks.Abstractions.Domain.EventSourcing;

namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Define um contrato para um repositório de eventos (Event Store).
/// </summary>
public interface IEventStore
{
    /// <summary>
    /// Verifica se um stream específico existe no repositório.
    /// </summary>
    /// <param name="streamId">O ID do stream.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>True se o stream existir; caso contrário, false.</returns>
    Task<bool> StreamExists(string streamId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém os eventos para um stream específico.
    /// </summary>
    /// <param name="streamId">O ID do agregado ou stream.</param>
    /// <param name="fromVersion">A posição a partir da qual ler os eventos.</param>
    /// <param name="maxCount">O número máximo de eventos a serem lidos.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma coleção de eventos do stream.</returns>
    Task<IEnumerable<IStreamEvent>> GetStreamEventsAsync(
        string streamId,
        StreamReadPosition? fromVersion = null,
        int maxCount = int.MaxValue,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém os eventos para um stream específico.
    /// </summary>
    /// <param name="streamId">O ID do agregado ou stream.</param>
    /// <param name="fromVersion">A posição a partir da qual ler os eventos.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma coleção de eventos do stream.</returns>
    Task<IEnumerable<IStreamEvent>> GetStreamEventsAsync(
        string streamId,
        StreamReadPosition? fromVersion = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona um evento a um stream.
    /// </summary>
    /// <param name="streamId">O ID do agregado ou stream.</param>
    /// <param name="event">O evento a ser adicionado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da operação de append.</returns>
    Task<AppendResult> AppendEventAsync(
        string streamId,
        IStreamEvent @event,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona um evento a um stream com uma versão esperada.
    /// </summary>
    /// <param name="streamId">O ID do agregado ou stream.</param>
    /// <param name="event">O evento a ser adicionado.</param>
    /// <param name="expectedRevision">A versão esperada do stream.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da operação de append.</returns>
    Task<AppendResult> AppendEventAsync(
        string streamId,
        IStreamEvent @event,
        ExpectedStreamVersion expectedRevision,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona uma coleção de eventos a um stream com uma versão esperada.
    /// </summary>
    /// <param name="streamId">O ID do agregado ou stream.</param>
    /// <param name="events">Os eventos a serem adicionados.</param>
    /// <param name="expectedRevision">A versão esperada do stream.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da operação de append.</returns>
    Task<AppendResult> AppendEventsAsync(
        string streamId,
        IReadOnlyCollection<IStreamEvent> events,
        ExpectedStreamVersion expectedRevision,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Reconstitui (reidrata) um agregado a partir dos eventos no Event Store.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="streamId">O ID do stream.</param>
    /// <param name="fromVersion">A posição a partir da qual ler os eventos.</param>
    /// <param name="defaultAggregateState">O estado inicial do agregado.</param>
    /// <param name="fold">A ação para aplicar os eventos ao agregado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O agregado reconstituído.</returns>
    Task<TAggregate?> AggregateStreamAsync<TAggregate, TId>(
        string streamId,
        StreamReadPosition fromVersion,
        TAggregate defaultAggregateState,
        Action<object> fold,
        CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();

    /// <summary>
    /// Reconstitui (reidrata) um agregado a partir dos eventos no Event Store.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="streamId">O ID do stream.</param>
    /// <param name="defaultAggregateState">O estado inicial do agregado.</param>
    /// <param name="fold">A ação para aplicar os eventos ao agregado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O agregado reconstituído.</returns>
    Task<TAggregate?> AggregateStreamAsync<TAggregate, TId>(
        string streamId,
        TAggregate defaultAggregateState,
        Action<object> fold,
        CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();

    /// <summary>
    /// Confirma os eventos no Event Store.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
}
