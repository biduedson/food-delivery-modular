namespace BuildingBlocks.Abstractions.Messaging.PersistMessage;

/// <summary>
/// Representa uma mensagem armazenada para persistência e processamento futuro (ex: Outbox Pattern).
/// </summary>
public class StoreMessage
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="StoreMessage"/>.
    /// </summary>
    /// <param name="id">O identificador da mensagem.</param>
    /// <param name="dataType">O tipo de dado da mensagem.</param>
    /// <param name="data">Os dados da mensagem (serializados).</param>
    /// <param name="deliveryType">O tipo de entrega da mensagem.</param>
    public StoreMessage(Guid id, string dataType, string data, MessageDeliveryType deliveryType)
    {
        Id = id;
        DataType = dataType;
        Data = data;
        DeliveryType = deliveryType;
        Created = DateTime.Now;
        MessageStatus = MessageStatus.Stored;
        RetryCount = 0;
    }

    /// <summary>
    /// O identificador da mensagem.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// O tipo de dado da mensagem.
    /// </summary>
    public string DataType { get; private set; }

    /// <summary>
    /// Os dados da mensagem (serializados).
    /// </summary>
    public string Data { get; private set; }

    /// <summary>
    /// A data de criação da mensagem.
    /// </summary>
    public DateTime Created { get; private set; }

    /// <summary>
    /// O número de tentativas de processamento.
    /// </summary>
    public int RetryCount { get; private set; }

    /// <summary>
    /// O status atual da mensagem.
    /// </summary>
    public MessageStatus MessageStatus { get; private set; }

    /// <summary>
    /// O tipo de entrega da mensagem.
    /// </summary>
    public MessageDeliveryType DeliveryType { get; private set; }

    /// <summary>
    /// Altera o status da mensagem.
    /// </summary>
    /// <param name="messageStatus">O novo status.</param>
    public void ChangeState(MessageStatus messageStatus)
    {
        MessageStatus = messageStatus;
    }

    /// <summary>
    /// Incrementa a contagem de tentativas.
    /// </summary>
    public void IncreaseRetry()
    {
        RetryCount++;
    }
}
