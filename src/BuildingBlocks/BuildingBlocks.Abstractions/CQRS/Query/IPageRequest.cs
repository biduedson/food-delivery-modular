namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define um contrato para requisições paginadas.
/// </summary>
public interface IPageRequest
{
    /// <summary>
    /// Lista de propriedades de navegação a serem incluídas na consulta.
    /// </summary>
    IList<string>? Includes { get; init; }

    /// <summary>
    /// Lista de filtros a serem aplicados na consulta.
    /// </summary>
    IList<FilterModel>? Filters { get; init; }

    /// <summary>
    /// Lista de ordenações a serem aplicadas na consulta.
    /// </summary>
    IList<string>? Sorts { get; init; }

    /// <summary>
    /// O número da página a ser retornada.
    /// </summary>
    int Page { get; init; }

    /// <summary>
    /// O tamanho da página a ser retornada.
    /// </summary>
    int PageSize { get; init; }
}
