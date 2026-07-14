namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para executar operações dentro de uma transação de banco de dados.
/// </summary>
public interface ITxDbContextExecution
{
    /// <summary>
    /// Executa uma ação dentro de uma transação.
    /// </summary>
    /// <param name="action">A ação a ser executada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task ExecuteTransactionalAsync(Func<Task> action, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executa uma função que retorna um valor dentro de uma transação.
    /// </summary>
    /// <typeparam name="T">O tipo do valor de retorno.</typeparam>
    /// <param name="action">A função a ser executada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da função.</returns>
    public Task<T> ExecuteTransactionalAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken = default);
}
