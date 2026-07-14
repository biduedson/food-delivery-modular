namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para o padrão Unidade de Trabalho (Unit of Work).
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Inicia uma nova transação.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirma a transação atual.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// Define um contrato para uma Unidade de Trabalho (Unit of Work) com um contexto específico.
/// </summary>
/// <typeparam name="TContext">O tipo do contexto do banco de dados.</typeparam>
public interface IUnitOfWork<out TContext> : IUnitOfWork
    where TContext : class
{
    /// <summary>
    /// Obtém o contexto do banco de dados.
    /// </summary>
    TContext Context { get; }
}
