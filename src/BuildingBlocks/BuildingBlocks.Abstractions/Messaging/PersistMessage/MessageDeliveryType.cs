namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// Enumeração para o tipo de entrega de uma mensagem.
/// </summary>
[Flags]
public enum MessageDeliveryType
{
    /// <summary>
    /// Mensagem de saída (Outbox).
    /// </summary>
    Outbox = 1,

    /// <summary>
    /// Mensagem de entrada (Inbox).
    /// </summary>
    Inbox = 2,

    /// <summary>
    /// Mensagem para processamento interno.
    /// </summary>
    Internal = 4
}
