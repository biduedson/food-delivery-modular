namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um evento de notificação de domínio que encapsula um evento de domínio.
/// </summary>
/// <typeparam name="TDomainEventType">O tipo do evento de domínio.</typeparam>
public interface IDomainNotificationEvent<TDomainEventType> : IDomainNotificationEvent
    where TDomainEventType : IDomainEvent
{
    /// <summary>
    /// O evento de domínio encapsulado.
    /// </summary>
    TDomainEventType DomainEvent { get; set; }
}

/// <summary>
/// Interface marcadora para eventos de notificação de domínio.
/// </summary>
public interface IDomainNotificationEvent : IEvent
{
}
