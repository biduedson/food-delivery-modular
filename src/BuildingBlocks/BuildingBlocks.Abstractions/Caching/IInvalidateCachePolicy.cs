using MediatR;

namespace BuildingBlocks.Abstractions.Caching;

/// <summary>
/// Define uma política de invalidação de cache para uma requisição e sua resposta.
/// </summary>
public interface IInvalidateCachePolicy<in TRequest, TResponse>
where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Gera a chave de cache a ser invalidada a partir da requisição informada.
    /// </summary>
    /// <param name="request">Requisição usada para compor a chave.</param>
    /// <returns>Chave de cache a ser invalidada.</returns>
    string GetCacheKey(TRequest request)
    {
        var r = new { request };
        var props = r.request.GetType().GetProperties().Select(pi => $"{pi.Name}:{pi.GetValue(r.request, null)}");
        return $"{typeof(TRequest).FullName}{{{string.Join(",", props)}}}";
    }
}

/// <summary>
/// Define uma política de invalidação de cache para requisições que retornam `Unit`.
/// </summary>
public interface IInvalidateCachePolicy<in TRequest> : IInvalidateCachePolicy<TRequest, Unit>
where TRequest : IRequest<Unit>
{
}