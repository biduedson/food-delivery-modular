namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define uma consulta para obter uma lista de itens, com suporte a paginação.
/// </summary>
/// <typeparam name="TResponse">O tipo da resposta, que deve ser uma lista de itens.</typeparam>
public interface IListQuery<out TResponse> : IPageRequest, IQuery<TResponse>
    where TResponse : notnull
{
}
