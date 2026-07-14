namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define um processador para enviar consultas.
/// </summary>
public interface IQueryProcessor
{
    /// <summary>
    /// Envia uma consulta que retorna um único resultado.
    /// </summary>
    /// <typeparam name="TResponse">O tipo da resposta.</typeparam>
    /// <param name="query">A consulta a ser enviada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado da consulta.</returns>
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        where TResponse : notnull;

    /// <summary>
    /// Envia uma consulta que retorna um stream de resultados.
    /// </summary>
    /// <typeparam name="TResponse">O tipo dos itens no stream.</typeparam>
    /// <param name="query">A consulta a ser enviada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Um stream assíncrono com os resultados da consulta.</returns>
    IAsyncEnumerable<TResponse> SendAsync<TResponse>(
        IStreamQuery<TResponse> query,
        CancellationToken cancellationToken = default)
        where TResponse : notnull;
}
