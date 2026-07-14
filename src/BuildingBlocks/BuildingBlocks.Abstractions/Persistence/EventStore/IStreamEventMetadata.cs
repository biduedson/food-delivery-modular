namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Define um contrato para os metadados de um evento de stream.
/// </summary>
public interface IStreamEventMetadata
{
    /// <summary>
    /// O identificador do evento.
    /// </summary>
    string EventId { get; }

    /// <summary>
    /// A posição do evento no log de transações (se aplicável).
    /// </summary>
    long? LogPosition { get; }

    /// <summary>
    /// A posição do evento no stream.
    /// </summary>
    long StreamPosition { get; }
}
