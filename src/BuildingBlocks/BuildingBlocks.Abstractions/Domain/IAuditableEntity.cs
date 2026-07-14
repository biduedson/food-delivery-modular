namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define uma entidade auditável com um identificador genérico.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IAuditableEntity<out TId> : IEntity<TId>, IHaveAudit
{
}

/// <summary>
/// Define uma entidade auditável com um tipo de identidade específico.
/// </summary>
/// <typeparam name="TIdentity">O tipo do objeto de identidade.</typeparam>
/// <typeparam name="TId">O tipo do valor do identificador.</typeparam>
public interface IAuditableEntity<out TIdentity, TId> : IAuditableEntity<TIdentity>
    where TIdentity : Identity<TId>
{
}

/// <summary>
/// Define uma entidade auditável com um identificador padrão.
/// </summary>
public interface IAuditableEntity : IAuditableEntity<Identity<long>, long>
{
}
