using BuildingBlocks.Abstractions.Messaging;

namespace BuildingBlocks.Abstractions.Serialization;

/// <summary>
/// Define uma interface para serialização e desserialização de mensagens, estendendo <see cref="ISerializer"/>.
/// </summary>
public interface IMessageSerializer : ISerializer
{
    /// <summary>
    /// Obtém o tipo de conteúdo (MIME type) que este serializador de mensagens manipula.
    /// </summary>
    new string ContentType { get; }

    /// <summary>
    /// Serializa o <see cref="MessageEnvelope"/> fornecido em uma string.
    /// </summary>
    /// <param name="messageEnvelope">Um <see cref="MessageEnvelope"/> que implementa a interface <see cref="IMessage"/>.</param>
    /// <returns>Uma string JSON para o <see cref="MessageEnvelope"/> serializado.</returns>
    string Serialize(MessageEnvelope messageEnvelope);

    /// <summary>
    /// Serializa a mensagem fornecida em uma string.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem, que deve implementar <see cref="IMessage"/>.</typeparam>
    /// <param name="message">A mensagem a ser serializada.</param>
    /// <returns>Uma string JSON para a mensagem serializada.</returns>
    string Serialize<TMessage>(TMessage message)
        where TMessage : IMessage;

    /// <summary>
    /// Desserializa a string JSON fornecida em um <see cref="MessageEnvelope"/>.
    /// </summary>
    /// <param name="json">Os dados JSON para desserializar em um <see cref="MessageEnvelope"/>.</param>
    /// <returns>Um objeto <see cref="MessageEnvelope"/>, ou null se a desserialização falhar.</returns>
    MessageEnvelope? Deserialize(string json);

    /// <summary>
    /// Desserializa o array de bytes fornecido de volta em uma mensagem.
    /// </summary>
    /// <param name="data">Os dados em array de bytes a serem desserializados.</param>
    /// <param name="payloadType">O tipo de payload da mensagem.</param>
    /// <returns>Um objeto <see cref="IMessage"/>, ou null se a desserialização falhar.</returns>
    IMessage? Deserialize(ReadOnlySpan<byte> data, string payloadType);

    /// <summary>
    /// Desserializa a string fornecida em uma mensagem do tipo <typeparamref name="TMessage"/>.
    /// </summary>
    /// <typeparam name="TMessage">O tipo da mensagem para o qual a string deve ser desserializada.</typeparam>
    /// <param name="message">A string a ser desserializada.</param>
    /// <returns>O objeto <typeparamref name="TMessage"/> desserializado, ou null se a desserialização falhar.</returns>
    TMessage? Deserialize<TMessage>(string message)
        where TMessage : IMessage;

    /// <summary>
    /// Desserializa a string fornecida em um objeto.
    /// </summary>
    /// <param name="payload">A string a ser desserializada.</param>
    /// <param name="payloadType">O tipo de payload da mensagem.</param>
    /// <returns>O objeto desserializado, ou null se a desserialização falhar.</returns>
    object? Deserialize(string payload, string payloadType);
}
