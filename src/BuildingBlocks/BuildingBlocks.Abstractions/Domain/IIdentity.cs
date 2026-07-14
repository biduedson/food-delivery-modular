namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para objetos de identidade com um identificador genérico.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IIdentity<out TId>
{
    /// <summary>
    /// Obtém o valor do identificador.
    /// </summary>
    public TId Value { get; }
}
