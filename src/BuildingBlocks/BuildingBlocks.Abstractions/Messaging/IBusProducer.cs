namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para um produtor de mensagens do barramento.
/// </summary>
public interface IBusProducer
{
    /// <summary>
    /// Publica uma mensagem.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    /// <param name="message">A mensagem a ser publicada.</param>
    /// <param name="headers">Cabeçalhos adicionais para a mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync<TMessage>(
        TMessage message,
        IDictionary<string, object?>? headers = null,
        CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;

    /// <summary>
    /// Publica uma mensagem para um exchange/tópico ou fila específica.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
    /// <param name="message">A mensagem a ser publicada.</param>
    /// <param name="headers">Cabeçalhos adicionais para a mensagem.</param>
    /// <param name="exchangeOrTopic">O exchange ou tópico de destino.</param>
    /// <param name="queue">A fila de destino.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync<TMessage>(
        TMessage message,
        IDictionary<string, object?>? headers = null,
        string? exchangeOrTopic = null,
        string? queue = null,
        CancellationToken cancellationToken = default)
        where TMessage : class, IMessage;

    /// <summary>
    /// Publica um objeto de mensagem.
    /// </summary>
    /// <param name="message">A mensagem a ser publicada.</param>
    /// <param name="headers">Cabeçalhos adicionais para a mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync(
        object message,
        IDictionary<string, object?>? headers = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Publica um objeto de mensagem para um exchange/tópico ou fila específica.
    /// </summary>
    /// <param name="message">A mensagem a ser publicada.</param>
    /// <param name="headers">Cabeçalhos adicionais para a mensagem.</param>
    /// <param name="exchangeOrTopic">O exchange ou tópico de destino.</param>
    /// <param name="queue">A fila de destino.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    public Task PublishAsync(
        object message,
        IDictionary<string, object?>? headers = null,
        string? exchangeOrTopic = null,
        string? queue = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Evento disparado quando uma mensagem é publicada.
    /// </summary>
    event Action<object> MessagePublished;
}
