using BuildingBlocks.Abstractions.CQRS.Event.Internal;
using BuildingBlocks.Abstractions.Messaging;

namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um mapeador para converter eventos de domínio em outros tipos de eventos.
/// </summary>
public interface IEventMapper : IIDomainNotificationEventMapper, IIntegrationEventMapper
{
}

/// <summary>
/// Define um mapeador para converter eventos de domínio em eventos de notificação de domínio.
/// </summary>
public interface IIDomainNotificationEventMapper
{
    /// <summary>
    /// Mapeia uma lista de eventos de domínio para uma lista de eventos de notificação de domínio.
    /// </summary>
    /// <param name="domainEvents">Os eventos de domínio a serem mapeados.</param>
    /// <returns>Uma lista de eventos de notificação de domínio.</returns>
    IReadOnlyList<IDomainNotificationEvent?>? MapToDomainNotificationEvents(IReadOnlyList<IDomainEvent> domainEvents);

    /// <summary>
    /// Mapeia um evento de domínio para um evento de notificação de domínio.
    /// </summary>
    /// <param name="domainEvent">O evento de domínio a ser mapeado.</param>
    /// <returns>O evento de notificação de domínio mapeado.</returns>
    IDomainNotificationEvent? MapToDomainNotificationEvent(IDomainEvent domainEvent);
}

/// <summary>
/// Define um mapeador para converter eventos de domínio em eventos de integração.
/// </summary>
public interface IIntegrationEventMapper
{
    /// <summary>
    /// Mapeia uma lista de eventos de domínio para uma lista de eventos de integração.
    /// </summary>
    /// <param name="domainEvents">Os eventos de domínio a serem mapeados.</param>
    /// <returns>Uma lista de eventos de integração.</returns>
    IReadOnlyList<IIntegrationEvent?>? MapToIntegrationEvents(IReadOnlyList<IDomainEvent> domainEvents);

    /// <summary>
    /// Mapeia um evento de domínio para um evento de integração.
    /// </summary>
    /// <param name="domainEvent">O evento de domínio a ser mapeado.</param>
    /// <returns>O evento de integração mapeado.</returns>
    IIntegrationEvent? MapToIntegrationEvent(IDomainEvent domainEvent);
}
