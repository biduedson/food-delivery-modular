using MediatR;

namespace BuildingBlocks.Abstractions.Caching;

/// <summary>
/// Define as regras de cache para uma requisição e sua resposta.
/// </summary>
public interface ICachePolicy<in TRequest, TResponse>
where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Obtém o tempo de expiração relativa do cache.
    /// </summary>
    DateTime? AbsoluteExpirationRelativeToNow { get; }

    /// <summary>
    /// Gera a chave de cache a partir da requisição informada.
    /// </summary>
    /// <param name="request">Requisição usada para compor a chave.</param>
    /// <returns>Chave única de cache.</returns>
    string GetCacheKey(TRequest request)
    {
        var r = new { request };
        var props = r.request.GetType().GetProperties().Select(pi => $"{pi.Name}:{pi.GetValue(r.request, null)}");
        return $"{typeof(TRequest).FullName}{{{string.Join(",", props)}}}";
    }
}

/// <summary>
/// Define as regras de cache para requisições de stream.
/// </summary>
public interface IStreamCachePolicy<in TRequest, TResponse>
where TRequest : IStreamRequest<TResponse>
{
    /// <summary>
    /// Obtém o tempo de expiração relativa do cache.
    /// </summary>
    DateTime? AbsoluteExpirationRelativeToNow { get; }

    /// <summary>
    /// Gera a chave de cache a partir da requisição informada.
    /// </summary>
    /// <param name="request">Requisição usada para compor a chave.</param>
    /// <returns>Chave única de cache.</returns>
    string GetCacheKey(TRequest request)
    {
        var r = new { request };
        var props = r.request.GetType().GetProperties().Select(pi => $"{pi.Name}:{pi.GetValue(r.request, null)}");
        return $"{typeof(TRequest).FullName}{{{string.Join(",", props)}}}";
    }
}