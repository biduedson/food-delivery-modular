namespace BuildingBlocks.Abstractions.Caching;

/// <summary>
/// Define o contrato de um gerenciador de cache, com operações síncronas e assíncronas
/// para leitura, gravação, obtenção condicional e remoção de dados.
/// </summary>
public interface ICacheManager
{
    /// <summary>
    /// Obtém um valor de forma assíncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T?> GetAsync<T>(string key);

    /// <summary>
    /// Obtém um valor de forma síncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T? Get<T>(string key);

    /// <summary>
    /// Armazena um valor de forma assíncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value"></param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SetAsync<T>(string key, T value, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Resolve e armazena um valor de forma assíncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="acquire"></param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task SetAsync<T>(string key, Func<T> acquire, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Armazena um valor de forma síncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value"></param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T"></typeparam>
    void Set<T>(string key, T value, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Resolve e armazena um valor de forma síncrona.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="acquire"></param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T"></typeparam>
    void Set<T>(string key, Func<T> acquire, int? cacheTime = null)
        where T : notnull;

    /// <summary>Obtém um valor do cache ou o cria de forma assíncrona.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="acquireAsync">Função usada para criar o valor caso ele não exista no cache.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <returns>O valor obtido ou criado.</returns>
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>>? acquireAsync = null, int? cacheTime = null);

    /// <summary>Obtém um valor do cache ou o cria.</summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="acquire">Função usada para criar o valor caso ele não exista no cache.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <returns>O valor obtido ou criado.</returns>
    T? GetOrSet<T>(string key, Func<T>? acquire = null, int? cacheTime = null);

    /// <summary>Remove um valor do cache de forma assíncrona.</summary>
    /// <param name="key">The key.</param>
    /// <returns>Tarefa que representa a operação assíncrona.</returns>
    Task RemoveAsync(string key);

    /// <summary>Remove um valor do cache.</summary>
    /// <param name="key">The key.</param>
    void Remove(string key);
}