using MediatR;

namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para uma mensagem.
/// </summary>
public interface IMessage : INotification
{
    /// <summary>
    /// O identificador único da mensagem.
    /// </summary>
    Guid MessageId { get; }

    /// <summary>
    /// A data de criação da mensagem.
    /// </summary>
    DateTime Created { get; }
}
