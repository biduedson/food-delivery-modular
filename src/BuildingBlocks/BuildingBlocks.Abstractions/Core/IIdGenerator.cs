namespace BuildingBlocks.Abstractions.Core;

/// <summary>
/// Define um contrato para um gerador de identificadores únicos.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IIdGenerator<out TId>
{
    /// <summary>
    /// Gera um novo identificador único.
    /// </summary>
    /// <returns>Um novo identificador do tipo <typeparamref name="TId"/>.</returns>
     TId New();
}
