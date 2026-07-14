namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para um evento de integração, que é uma mensagem usada para comunicação entre diferentes Bounded Contexts.
/// </summary>
public interface IIntegrationEvent : IMessage
{
}
