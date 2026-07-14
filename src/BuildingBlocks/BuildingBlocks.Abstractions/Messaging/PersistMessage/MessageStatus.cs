namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// Enumeração para o status de uma mensagem persistida.
/// </summary>
public enum MessageStatus
{
    /// <summary>
    /// A mensagem está armazenada e aguardando processamento.
    /// </summary>
    Stored = 1,

    /// <summary>
    /// A mensagem foi processada com sucesso.
    /// </summary>
    Processed = 2
}
