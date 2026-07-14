namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Representa o resultado de uma operação de append (adição) de eventos a um stream.
/// </summary>
/// <param name="GlobalPosition">A posição global do evento no Event Store.</param>
/// <param name="NextExpectedVersion">A próxima versão esperada do stream.</param>
public record AppendResult(long GlobalPosition, long NextExpectedVersion)
{
    /// <summary>
    /// Um resultado de append nulo ou vazio.
    /// </summary>
    public static readonly AppendResult None = new(0, -1);
};
