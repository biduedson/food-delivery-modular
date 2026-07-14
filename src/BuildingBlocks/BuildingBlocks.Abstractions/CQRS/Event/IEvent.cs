using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Event;

/// <summary>
/// Define um evento, que representa algo que aconteceu no sistema.
/// </summary>
public interface IEvent : INotification
{
    /// <summary>
    /// O identificador único do evento.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// A versão do evento.
    /// </summary>
    long EventVersion { get; }

    /// <summary>
    /// A data e hora em que o evento ocorreu.
    /// </summary>
    DateTime OccurredOn { get; }

    /// <summary>
    /// O timestamp do evento.
    /// </summary>
    DateTimeOffset TimeStamp { get; }

    /// <summary>
    /// O tipo do evento.
    /// </summary>
    public string EventType { get; }
}
