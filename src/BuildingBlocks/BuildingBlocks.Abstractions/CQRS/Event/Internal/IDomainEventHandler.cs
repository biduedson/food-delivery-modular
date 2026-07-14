namespace BuildingBlocks.Abstractions.CQRS.Event.Internal;

/// <summary>
/// Define um manipulador para um evento de domínio.
/// </summary>
/// <typeparam name="TEvent">O tipo do evento de domínio.</typeparam>
public interface IDomainEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IDomainEvent
{
}
