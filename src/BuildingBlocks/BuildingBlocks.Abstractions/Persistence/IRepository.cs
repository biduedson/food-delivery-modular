using System.Linq.Expressions;
using BuildingBlocks.Abstractions.Domain;

namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para um repositório de leitura.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TId">O tipo do identificador da entidade.</typeparam>
public interface IReadRepository<TEntity, in TId>
    where TEntity : class, IHaveIdentity<TId>
{
    /// <summary>
    /// Encontra uma entidade pelo seu identificador.
    /// </summary>
    /// <param name="id">O identificador da entidade.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>A entidade, se encontrada; caso contrário, nulo.</returns>
    Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Encontra a primeira entidade que corresponde a um predicado.
    /// </summary>
    /// <param name="predicate">O predicado de busca.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>A entidade, se encontrada; caso contrário, nulo.</returns>
    Task<TEntity?> FindOneAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Encontra todas as entidades que correspondem a um predicado.
    /// </summary>
    /// <param name="predicate">O predicado de busca.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma lista de entidades.</returns>
    Task<IReadOnlyList<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todas as entidades.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma lista de todas as entidades.</returns>
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Define um contrato para um repositório de escrita.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TId">O tipo do identificador da entidade.</typeparam>
public interface IWriteRepository<TEntity, in TId>
    where TEntity : class, IHaveIdentity<TId>
{
    /// <summary>
    /// Adiciona uma nova entidade.
    /// </summary>
    /// <param name="entity">A entidade a ser adicionada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>A entidade adicionada.</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Atualiza uma entidade existente.
    /// </summary>
    /// <param name="entity">A entidade a ser atualizada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>A entidade atualizada.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deleta uma lista de entidades.
    /// </summary>
    /// <param name="entities">As entidades a serem deletadas.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteRangeAsync(IReadOnlyList<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deleta entidades com base em um predicado.
    /// </summary>
    /// <param name="predicate">O predicado de exclusão.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deleta uma entidade específica.
    /// </summary>
    /// <param name="entity">A entidade a ser deletada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deleta uma entidade pelo seu identificador.
    /// </summary>
    /// <param name="id">O identificador da entidade.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
}

/// <summary>
/// Define um contrato para um repositório completo (leitura e escrita).
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TId">O tipo do identificador da entidade.</typeparam>
public interface IRepository<TEntity, in TId> :
    IReadRepository<TEntity, TId>,
    IWriteRepository<TEntity, TId>,
    IDisposable
    where TEntity : class, IHaveIdentity<TId>
{
}

/// <summary>
/// Define um contrato para um repositório completo com identificador do tipo <see cref="long"/>.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
public interface IRepository<TEntity> : IRepository<TEntity, long>
    where TEntity : class, IHaveIdentity<long>
{
}
