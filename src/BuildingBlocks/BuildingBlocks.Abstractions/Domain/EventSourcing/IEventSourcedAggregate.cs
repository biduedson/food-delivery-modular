using BuildingBlocks.Abstractions.Persistence.EventStore;

namespace BuildingBlocks.Abstractions.Domain.EventSourcing;

/// <summary>
/// Define um agregado que utiliza Event Sourcing, com um identificador genérico.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IEventSourcedAggregate<out TId> : IEntity<TId>, IHaveEventSourcingAggregate
{
}

/// <summary>
/// Define um agregado que utiliza Event Sourcing, com um tipo de identidade específico.
/// </summary>
/// <typeparam name="TIdentity">O tipo do objeto de identidade.</typeparam>
/// <typeparam name="TId">O tipo do valor do identificador.</typeparam>
public interface IEventSourcedAggregate<out TIdentity, TId> : IEventSourcedAggregate<TIdentity>
    where TIdentity : Identity<TId>
{
}

/// <summary>
/// Define um agregado que utiliza Event Sourcing, com um identificador padrão.
/// </summary>
public interface IEventSourcedAggregate : IEventSourcedAggregate<AggregateId, long>
{
}
