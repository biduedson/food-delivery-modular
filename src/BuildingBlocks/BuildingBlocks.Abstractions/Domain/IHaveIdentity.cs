namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para objetos que possuem um identificador com tipo genérico.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IHaveIdentity<out TId> : IHaveIdentity
{
    /// <summary>
    /// O identificador do objeto.
    /// </summary>
    new TId Id { get; }
    object IHaveIdentity.Id => Id;
}

/// <summary>
/// Define um contrato para objetos que possuem um identificador.
/// </summary>
public interface IHaveIdentity
{
    /// <summary>
    /// O identificador do objeto.
    /// </summary>
    object Id { get; }
}
