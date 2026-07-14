using BuildingBlocks.Abstractions.Domain;

namespace BuildingBlocks.Abstractions.Persistence.Mongo;

/// <summary>
/// Define um contrato para um repositório MongoDB.
/// </summary>
/// <typeparam name="TEntity">O tipo da entidade.</typeparam>
/// <typeparam name="TId">O tipo do identificador da entidade.</typeparam>
public interface IMongoRepository<TEntity, in TId> : IRepository<TEntity, TId>
    where TEntity : class, IHaveIdentity<TId>
{
}
