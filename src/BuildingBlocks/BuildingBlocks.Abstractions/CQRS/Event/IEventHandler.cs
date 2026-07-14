using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um manipulador para um evento.
/// </summary>
/// <typeparam name="TEvent">O tipo do evento.</typeparam>
public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
}
