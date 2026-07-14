using BuildingBlocks.Abstractions.CQRS.Event;

namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um manipulador para um evento de integração.
/// </summary>
/// <typeparam name="TEvent">O tipo do evento de integração.</typeparam>
public interface IIntegrationEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IIntegrationEvent
{
}
