namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define uma consulta para obter um único item pelo seu identificador.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
/// <typeparam name="TResponse">O tipo da resposta.</typeparam>
public interface IItemQuery<TId, out TResponse> : IQuery<TResponse>
    where TId : struct
    where TResponse : notnull
{
    /// <summary>
    /// Lista de propriedades de navegação a serem incluídas na consulta.
    /// </summary>
    public IList<string> Includes { get; }

    /// <summary>
    /// O identificador do item a ser consultado.
    /// </summary>
    public TId Id { get; }
}
