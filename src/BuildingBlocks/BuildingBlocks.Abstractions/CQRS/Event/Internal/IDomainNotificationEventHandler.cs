namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um manipulador para um evento de notificação de domínio.
/// </summary>
/// <typeparam name="TEvent">O tipo do evento de notificação de domínio.</typeparam>
public interface IDomainNotificationEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IDomainNotificationEvent
{
}
