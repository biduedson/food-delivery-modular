using System.Linq.Expressions;

namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// Define um repositório para gerenciar a persistência de mensagens.
/// </summary>
public interface IMessagePersistenceRepository
{
    /// <summary>
    /// Adiciona uma mensagem ao repositório.
    /// </summary>
    /// <param name="storeMessage">A mensagem a ser adicionada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddAsync(StoreMessage storeMessage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém todas as mensagens do repositório.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma lista de todas as mensagens armazenadas.</returns>
    Task<IReadOnlyList<StoreMessage>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém mensagens do repositório com base em um filtro.
    /// </summary>
    /// <param name="predicate">A expressão de filtro.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma lista de mensagens que correspondem ao filtro.</returns>
    Task<IReadOnlyList<StoreMessage>> GetByFilterAsync(
        Expression<Func<StoreMessage, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtém uma mensagem pelo seu identificador.
    /// </summary>
    /// <param name="id">O identificador da mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>A mensagem, se encontrada; caso contrário, nulo.</returns>
    Task<StoreMessage?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove uma mensagem do repositório.
    /// </summary>
    /// <param name="storeMessage">A mensagem a ser removida.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>True se a mensagem foi removida com sucesso; caso contrário, false.</returns>
    Task<bool> RemoveAsync(StoreMessage storeMessage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Realiza a limpeza de mensagens antigas ou processadas.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task CleanupMessages();
}
