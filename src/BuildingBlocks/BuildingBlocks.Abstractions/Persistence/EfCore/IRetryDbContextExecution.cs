namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para executar operações de banco de dados com uma política de nova tentativa (retry).
/// </summary>
public interface IRetryDbContextExecution
{
    /// <summary>
    /// Executa uma operação com nova tentativa em caso de exceção.
    /// </summary>
    /// <param name="operation">A operação a ser executada.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task RetryOnExceptionAsync(Func<Task> operation);

    /// <summary>
    /// Executa uma operação que retorna um valor com nova tentativa em caso de exceção.
    /// </summary>
    /// <typeparam name="TResult">O tipo do resultado.</typeparam>
    /// <param name="operation">A operação a ser executada.</param>
    /// <returns>O resultado da operação.</returns>
    Task<TResult> RetryOnExceptionAsync<TResult>(Func<Task<TResult>> operation);
}
