namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Representa um envelope de mensagem, que encapsula a mensagem e seus cabeçalhos.
/// Padrão: Envelope Wrapper.
/// </summary>
public class MessageEnvelope
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="MessageEnvelope"/>.
    /// </summary>
    /// <param name="message">A mensagem.</param>
    /// <param name="headers">Os cabeçalhos da mensagem.</param>
    public MessageEnvelope(object message, IDictionary<string, object?>? headers = null)
    {
        Message = message;
        Headers = headers ?? new Dictionary<string, object?>();
    }

    /// <summary>
    /// Obtém a mensagem.
    /// </summary>
    public object Message { get; init; }

    /// <summary>
    /// Obtém os cabeçalhos da mensagem.
    /// </summary>
    public IDictionary<string, object?> Headers { get; init; }
}

/// <summary>
/// Representa um envelope de mensagem com um tipo de mensagem específico.
/// </summary>
/// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
public class MessageEnvelope<TMessage> : MessageEnvelope
    where TMessage : class, IMessage
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="MessageEnvelope{TMessage}"/>.
    /// </summary>
    /// <param name="message">A mensagem.</param>
    /// <param name="header">Os cabeçalhos da mensagem.</param>
    public MessageEnvelope(TMessage message, IDictionary<string, object?> header) : base(message, header)
    {
        Message = message;
    }

    /// <summary>
    /// Obtém a mensagem com seu tipo específico.
    /// </summary>
    public new TMessage Message { get; }
}
