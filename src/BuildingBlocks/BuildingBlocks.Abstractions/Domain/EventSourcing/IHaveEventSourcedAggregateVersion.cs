namespace BuildingBlocks.Abstractions.Domain.EventSourcing;

/// <summary>
/// Define um contrato para agregados com versionamento para Event Sourcing.
/// </summary>
public interface IHaveEventSourcedAggregateVersion : IHaveAggregateVersion
{
    /// <summary>
    /// A versão atual do agregado. É definida para a versão original quando o agregado é carregado
    /// e deve ser incrementada a cada transição de estado.
    /// </summary>
    long CurrentVersion { get; }
}
