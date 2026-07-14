using System.Diagnostics;

namespace BuildingBlocks.Abstractions.Messaging.Context;

/// <summary>
/// Define o contexto de consumo para uma mensagem com tipo específico.
/// </summary>
/// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
public interface IConsumeContext<out TMessage> : IConsumeContext
    where TMessage : class, IMessage
{
    /// <summary>
    /// Obtém a mensagem com seu tipo específico.
    /// </summary>
    new TMessage Message { get; }
}

/// <summary>
/// Define o contexto de consumo para uma mensagem.
/// </summary>
public interface IConsumeContext
{
    /// <summary>
    /// Obtém a mensagem como um objeto.
    /// </summary>
    object Message { get; }

    /// <summary>
    /// Obtém os cabeçalhos da mensagem.
    /// </summary>
    IDictionary<string, object?> Headers { get; }

    /// <summary>
    /// Obtém ou define o contexto pai para rastreamento distribuído.
    /// </summary>
    ActivityContext? ParentContext { get; set; }

    /// <summary>
    /// Obtém o identificador da mensagem.
    /// </summary>
    Guid MessageId { get; }

    /// <summary>
    /// Obtém o tipo da mensagem.
    /// </summary>
    string MessageType { get; }

    /// <summary>
    /// Obtém a coleção de itens de contexto.
    /// </summary>
    ContextItems Items { get; }

    /// <summary>
    /// Obtém o tamanho da carga útil da mensagem.
    /// </summary>
    int PayloadSize { get; }

    /// <summary>
    /// Obtém a versão da mensagem.
    /// </summary>
    ulong Version { get; }

    /// <summary>
    /// Obtém a data de criação da mensagem.
    /// </summary>
    DateTime Created { get; }
}
