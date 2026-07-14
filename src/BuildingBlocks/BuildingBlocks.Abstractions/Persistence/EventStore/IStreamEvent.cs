using BuildingBlocks.Abstractions.CQRS.Event;
using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Define um contrato para um evento que pertence a um stream no Event Store.
/// </summary>
public interface IStreamEvent : IEvent
{
    /// <summary>
    /// Os dados do evento de domínio.
    /// </summary>
    public IDomainEvent Data { get; }

    /// <summary>
    /// Os metadados do evento do stream.
    /// </summary>
    public IStreamEventMetadata? Metadata { get; }
}

/// <summary>
/// Define um contrato para um evento de stream com um tipo de dado de domínio específico.
/// </summary>
/// <typeparam name="T">O tipo do evento de domínio.</typeparam>
public interface IStreamEvent<out T> : IStreamEvent
    where T : IDomainEvent
{
    /// <summary>
    /// Os dados do evento de domínio com tipo específico.
    /// </summary>
    public new T Data { get; }
}
