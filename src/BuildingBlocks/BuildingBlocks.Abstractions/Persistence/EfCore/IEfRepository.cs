using System.Linq.Expressions;
using BuildingBlocks.Abstractions.Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para um repositório do Entity Framework com funcionalidades adicionais.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TId">O tipo do identificador da entidade.</typeparam>
public interface IEfRepository<TEntity, in TId> : IRepository<TEntity, TId>
    where TEntity : class, IHaveIdentity<TId>
{
    /// <summary>
    /// Obtém entidades com inclusão de propriedades de navegação.
    /// </summary>
    /// <param name="includes">As inclusões a serem aplicadas.</param>
    /// <returns>Uma coleção de entidades.</returns>
    IEnumerable<TEntity> GetInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null);

    /// <summary>
    /// Obtém entidades com base em um predicado e com inclusão de propriedades de navegação.
    /// </summary>
    /// <param name="predicate">O predicado de busca.</param>
    /// <param name="includes">As inclusões a serem aplicadas.</param>
    /// <param name="withTracking">Indica se o rastreamento de alterações deve ser usado.</param>
    /// <returns>Uma coleção de entidades.</returns>
    IEnumerable<TEntity> GetInclude(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null,
        bool withTracking = true);

    /// <summary>
    /// Obtém entidades de forma assíncrona com inclusão de propriedades de navegação.
    /// </summary>
    /// <param name="includes">As inclusões a serem aplicadas.</param>
    /// <returns>Uma coleção de entidades.</returns>
    Task<IEnumerable<TEntity>> GetIncludeAsync(
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null);

    /// <summary>
    /// Obtém entidades de forma assíncrona com base em um predicado e com inclusão de propriedades de navegação.
    /// </summary>
    /// <param name="predicate">O predicado de busca.</param>
    /// <param name="includes">As inclusões a serem aplicadas.</param>
    /// <param name="withTracking">Indica se o rastreamento de alterações deve ser usado.</param>
    /// <returns>Uma coleção de entidades.</returns>
    Task<IEnumerable<TEntity>> GetIncludeAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes = null,
        bool withTracking = true);
}
