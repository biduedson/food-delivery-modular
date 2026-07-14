namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um publicador para eventos de domínio.
/// </summary>
public interface IDomainEventPublisher
{
    /// <summary>
    /// Publica um evento de domínio.
    /// </summary>
    /// <param name="domainEvent">O evento de domínio a ser publicado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);

    /// <summary>
    /// Publica uma lista de eventos de domínio.
    /// </summary>
    /// <param name="domainEvents">Os eventos de domínio a serem publicados.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync(IDomainEvent[] domainEvents, CancellationToken cancellationToken = default);
}
