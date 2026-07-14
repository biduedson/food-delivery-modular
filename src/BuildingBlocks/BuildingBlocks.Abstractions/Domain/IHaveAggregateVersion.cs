namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para objetos que possuem versionamento, como agregados.
/// </summary>
public interface IHaveAggregateVersion
{
    /// <summary>
    /// A versão original do agregado, usada para controle de concorrência otimista.
    /// </summary>
    long OriginalVersion { get; }
}
