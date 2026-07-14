using System.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para um contexto de banco de dados do Entity Framework.
/// </summary>
public interface IDbContext : ITxDbContextExecution, IRetryDbContextExecution
{
    /// <summary>
    /// Cria um <see cref="DbSet{TEntity}"/> que pode ser usado para consultar e salvar instâncias de TEntity.
    /// </summary>
    /// <typeparam name="TEntity">O tipo da entidade.</typeparam>
    /// <returns>Um DbSet para o tipo de entidade fornecido.</returns>
    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

    /// <summary>
    /// Inicia uma nova transação com um nível de isolamento específico.
    /// </summary>
    /// <param name="isolationLevel">O nível de isolamento da transação.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default);

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
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Salva as entidades, despachando eventos de domínio se houver.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>True se as entidades foram salvas com sucesso; caso contrário, false.</returns>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Salva todas as alterações feitas neste contexto no banco de dados.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O número de entradas de estado gravadas no banco de dados.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
