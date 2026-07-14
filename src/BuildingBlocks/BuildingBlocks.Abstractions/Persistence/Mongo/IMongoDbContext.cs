using MongoDB.Driver;

namespace BuildingBlocks.Abstractions.Persistence.Mongo;

/// <summary>
/// Define um contrato para um contexto de banco de dados MongoDB.
/// </summary>
public interface IMongoDbContext : IDisposable
{
    /// <summary>
    /// Obtém uma coleção do MongoDB.
    /// </summary>
    /// <typeparam name="T">O tipo do documento.</typeparam>
    /// <param name="name">O nome da coleção.</param>
    /// <returns>A instância de <see cref="IMongoCollection{T}"/>.</returns>
    IMongoCollection<T> GetCollection<T>(string? name = null);

    /// <summary>
    /// Salva as alterações (executa os comandos adicionados).
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O número de comandos executados.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

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
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Reverte a transação atual.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task RollbackTransaction(CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona um comando para ser executado na transação.
    /// </summary>
    /// <param name="func">A função que representa o comando.</param>
    void AddCommand(Func<Task> func);
}
