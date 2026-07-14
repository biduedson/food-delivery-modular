using System.Linq.Expressions;
using BuildingBlocks.Abstractions.CQRS.Command;
using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// Define um serviço para persistir e processar mensagens (Outbox/Inbox Pattern).
/// </summary>
public interface IMessagePersistenceService
{
    /// <summary>
    /// Obtém mensagens persistidas com base em um filtro.
    /// </summary>
    /// <param name="predicate">A expressão de filtro.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma lista de mensagens armazenadas.</returns>
    Task<IReadOnlyList<StoreMessage>> GetByFilterAsync(
        Expression<Func<StoreMessage, bool>>? predicate = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adiciona uma mensagem para publicação (Outbox).
    /// </summary>
    /// <typeparam name="TMessageEnvelope">O tipo do envelope da mensagem.</typeparam>
    /// <param name="messageEnvelope">O envelope da mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddPublishMessageAsync<TMessageEnvelope>(
        TMessageEnvelope messageEnvelope,
        CancellationToken cancellationToken = default)
        where TMessageEnvelope : MessageEnvelope;

    /// <summary>
    /// Adiciona uma mensagem recebida (Inbox).
    /// </summary>
    /// <typeparam name="TMessageEnvelope">O tipo do envelope da mensagem.</typeparam>
    /// <param name="messageEnvelope">O envelope da mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddReceivedMessageAsync<TMessageEnvelope>(
        TMessageEnvelope messageEnvelope,
        CancellationToken cancellationToken = default)
        where TMessageEnvelope : MessageEnvelope;

    /// <summary>
    /// Adiciona um comando interno para processamento.
    /// </summary>
    /// <typeparam name="TCommand">O tipo do comando interno.</typeparam>
    /// <param name="internalCommand">O comando interno.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddInternalMessageAsync<TCommand>(
        TCommand internalCommand,
        CancellationToken cancellationToken = default)
        where TCommand : class, IInternalCommand;

    /// <summary>
    /// Adiciona um evento de notificação de domínio para processamento.
    /// </summary>
    /// <param name="notification">O evento de notificação.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task AddNotificationAsync(
        IDomainNotificationEvent notification,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Processa uma mensagem específica.
    /// </summary>
    /// <param name="messageId">O identificador da mensagem.</param>
    /// <param name="deliveryType">O tipo de entrega da mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task ProcessAsync(Guid messageId, MessageDeliveryType deliveryType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Processa todas as mensagens pendentes.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task ProcessAllAsync(CancellationToken cancellationToken = default);
}
