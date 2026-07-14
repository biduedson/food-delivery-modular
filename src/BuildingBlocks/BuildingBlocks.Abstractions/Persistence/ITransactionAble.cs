namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para objetos que podem participar de uma transação.
/// </summary>
public interface ITransactionAble
{
    /// <summary>
    /// Inicia uma nova transação.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Reverte a transação atual.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Confirma a transação atual.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
}
