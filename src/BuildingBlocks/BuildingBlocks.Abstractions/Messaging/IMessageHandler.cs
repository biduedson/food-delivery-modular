using BuildingBlocks.Abstractions.Messaging.Context;

namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para um manipulador de mensagens.
/// </summary>
/// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
public interface IMessageHandler<in TMessage>
    where TMessage : class, IMessage
{
    /// <summary>
    /// Manipula uma mensagem.
    /// </summary>
    /// <param name="messageContext">O contexto de consumo da mensagem.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task HandleAsync(IConsumeContext<TMessage> messageContext, CancellationToken cancellationToken = default);
}
