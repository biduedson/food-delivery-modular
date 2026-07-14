using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para uma Unidade de Trabalho (Unit of Work) específica do Entity Framework.
/// </summary>
public interface IEfUnitOfWork : IUnitOfWork, ITransactionAble, ITxDbContextExecution, IRetryDbContextExecution
{
}

/// <summary>
/// Define um contrato para uma Unidade de Trabalho (Unit of Work) genérica do Entity Framework.
/// </summary>
/// <typeparam name="TContext">O tipo do DbContext.</typeparam>
public interface IEfUnitOfWork<out TContext> : IEfUnitOfWork
    where TContext : DbContext
{
    /// <summary>
    /// Obtém o contexto do banco de dados.
    /// </summary>
    /// <returns>A instância de <typeparamref name="TContext"/>.</returns>
    TContext DbContext { get; }
}
