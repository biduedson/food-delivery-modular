using Ardalis.GuardClauses;

namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Representa o identificador de uma entidade, usando um <see cref="long"/> como tipo subjacente.
/// </summary>
public record EntityId : EntityId<long>
{
    public EntityId(long id) : base(id)
    {
    }

    public static implicit operator long(EntityId id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator EntityId(long id) => new(id);
}

/// <summary>
/// Representa o identificador de uma entidade com um tipo genérico.
/// </summary>
/// <typeparam name="T">O tipo do valor do identificador.</typeparam>
public record EntityId<T> : Identity<T>
{
    public EntityId(T id) : base(id)
    {
    }

    public static implicit operator T(EntityId<T> id) => Guard.Against.Null(id.Value, nameof(id.Value));
    public static implicit operator EntityId<T>(T id) => new(id);
}
