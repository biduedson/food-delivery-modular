namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define uma entidade com um identificador genérico.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IEntity<out TId> : IHaveIdentity<TId>, IHaveCreator
{
}

/// <summary>
/// Define uma entidade com um tipo de identidade específico.
/// </summary>
/// <typeparam name="TIdentity">O tipo do objeto de identidade.</typeparam>
/// <typeparam name="TId">O tipo do valor do identificador.</typeparam>
public interface IEntity<out TIdentity, in TId> : IEntity<TIdentity>
    where TIdentity : IIdentity<TId>
{
}

/// <summary>
/// Define uma entidade com um identificador padrão do tipo EntityId.
/// </summary>
public interface IEntity : IEntity<EntityId>
{
}
