namespace BuildingBlocks.Abstractions.Caching;

/// <summary>
/// Define as operações básicas de acesso ao provedor de cache.
/// </summary>
public interface ICacheProvider
{
    /// <summary>
    /// Obtém um valor do cache de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Valor encontrado ou nulo.</returns>
    Task<T?> GetAsync<T>(string key);

    /// <summary>
    /// Obtém um valor do cache de forma síncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Valor encontrado ou nulo.</returns>
    T? Get<T>(string key);

    /// <summary>
    /// Armazena um valor no cache de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="data">Dados a serem armazenados.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    Task SetAsync(string key, object data, int? cacheTime = null);

    /// <summary>
    /// Armazena um valor no cache de forma síncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="data">Dados a serem armazenados.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    void Set(string key, object data, int? cacheTime = null);

    /// <summary>
    /// Verifica de forma assíncrona se um item existe no cache.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Verdadeiro quando o item existir no cache.</returns>
    Task<bool> IsSetAsync(string key);

    /// <summary>
    /// Verifica de forma síncrona se um item existe no cache.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Verdadeiro quando o item existir no cache.</returns>
    bool IsSet(string key);

    /// <summary>
    /// Remove um item do cache de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Tarefa que representa a operação assíncrona.</returns>
    Task RemoveAsync(string key);

    /// <summary>
    /// Remove um item do cache.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    void Remove(string key);
}