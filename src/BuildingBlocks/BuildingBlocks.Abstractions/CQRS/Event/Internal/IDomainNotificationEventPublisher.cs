namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um publicador para eventos de notificação de domínio.
/// </summary>
public interface IDomainNotificationEventPublisher
{
    /// <summary>
    /// Publica um evento de notificação de domínio.
    /// </summary>
    /// <param name="domainNotificationEvent">O evento de notificação de domínio a ser publicado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync(IDomainNotificationEvent domainNotificationEvent, CancellationToken cancellationToken = default);

    /// <summary>
    /// Publica uma lista de eventos de notificação de domínio.
    /// </summary>
    /// <param name="domainNotificationEvents">Os eventos de notificação de domínio a serem publicados.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync(IDomainNotificationEvent[] domainNotificationEvents, CancellationToken cancellationToken = default);
}
