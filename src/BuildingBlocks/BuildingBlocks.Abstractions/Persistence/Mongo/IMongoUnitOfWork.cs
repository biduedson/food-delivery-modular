namespace BuildingBlocks.Abstractions.Persistence.Mongo;

/// <summary>
/// Define um contrato para uma Unidade de Trabalho (Unit of Work) específica do MongoDB.
/// </summary>
/// <typeparam name="TContext">O tipo do contexto do MongoDB.</typeparam>
public interface IMongoUnitOfWork<out TContext> : IUnitOfWork<TContext> where TContext : class, IMongoDbContext
{
}
