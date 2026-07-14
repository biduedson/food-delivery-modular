using BuildingBlocks.Abstractions.Domain;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para um repositório com suporte a paginação.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TKey">O tipo da chave da entidade.</typeparam>
public interface IPageRepository<TEntity, TKey>
    where TEntity : IHaveIdentity<TKey>
{
}

/// <summary>
/// Define um contrato para um repositório com suporte a paginação e chave do tipo <see cref="Guid"/>.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
public interface IPageRepository<TEntity> : IPageRepository<TEntity, Guid>
    where TEntity : IHaveIdentity<Guid>
{
}
