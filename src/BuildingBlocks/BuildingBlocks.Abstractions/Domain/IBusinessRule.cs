namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para uma regra de negócio.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Verifica se a regra de negócio foi violada.
    /// </summary>
    /// <returns>True se a regra foi violada; caso contrário, false.</returns>
    bool IsBroken();

    /// <summary>
    /// A mensagem de erro associada à regra de negócio violada.
    /// </summary>
    string Message { get; }
}
