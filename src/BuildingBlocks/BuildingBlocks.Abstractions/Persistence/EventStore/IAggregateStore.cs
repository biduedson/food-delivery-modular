using BuildingBlocks.Abstractions.Domain.EventSourcing;

namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Atua como um repositório para o AggregateRoot em um cenário de Event Sourcing.
/// </summary>
public interface IAggregateStore
{
    /// <summary>
    /// Carrega um agregado do repositório a partir do seu ID.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="aggregateId">O ID do agregado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O agregado, se encontrado; caso contrário, nulo.</returns>
    Task<TAggregate?> GetAsync<TAggregate, TId>(
        TId aggregateId,
        CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();

    /// <summary>
    /// Armazena o estado de um agregado no repositório.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="aggregate">O agregado a ser salvo.</param>
    /// <param name="expectedVersion">A versão esperada do stream.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da operação de append.</returns>
    Task<AppendResult> StoreAsync<TAggregate, TId>(
        TAggregate aggregate,
        ExpectedStreamVersion? expectedVersion = null,
        CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();

    /// <summary>
    /// Armazena o estado de um agregado no repositório.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="aggregate">O agregado a ser salvo.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da operação de append.</returns>
    Task<AppendResult> StoreAsync<TAggregate, TId>(
        TAggregate aggregate,
        CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();

    /// <summary>
    /// Verifica se um agregado existe no repositório.
    /// </summary>
    /// <typeparam name="TAggregate">O tipo do agregado.</typeparam>
    /// <typeparam name="TId">O tipo do ID do agregado.</typeparam>
    /// <param name="aggregateId">O ID do agregado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>True se o agregado existir; caso contrário, false.</returns>
    Task<bool> Exists<TAggregate, TId>(TId aggregateId, CancellationToken cancellationToken = default)
        where TAggregate : class, IEventSourcedAggregate<TId>, new();
}
