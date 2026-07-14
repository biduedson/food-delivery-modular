using BuildingBlocks.Abstractions.Messaging.Context;

namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Delegate para manipular uma mensagem.
/// </summary>
/// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
/// <param name="context">O contexto de consumo da mensagem.</param>
/// <param name="cancellationToken">O token de cancelamento.</param>
/// <returns>Uma tarefa que representa a operação assíncrona.</returns>
public delegate Task MessageHandler<in TMessage>(
    IConsumeContext<TMessage> context,
    CancellationToken cancellationToken = default)
    where TMessage : class, IMessage;

/// <summary>
/// Delegate para manipular uma mensagem e retornar uma confirmação (acknowledgement).
/// </summary>
/// <typeparam name="TMessage">O tipo da mensagem.</typeparam>
/// <param name="context">O contexto de consumo da mensagem.</param>
/// <param name="cancellationToken">O token de cancelamento.</param>
/// <returns>Um <see cref="Acknowledgement"/> que indica o resultado do processamento.</returns>
public delegate Task<Acknowledgement> MessageHandlerAck<in TMessage>(
    IConsumeContext<TMessage> context,
    CancellationToken cancellationToken = default)
    where TMessage : class, IMessage;
