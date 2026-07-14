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
    /// <param name="key">Chave do item.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <returns>Valor encontrado ou nulo.</returns>
    Task<T?> GetAsync<T>(string key);

    /// <summary>
    /// Obtém um valor de forma síncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <returns>Valor encontrado ou nulo.</returns>
    T? Get<T>(string key);

    /// <summary>
    /// Armazena um valor de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="value">Valor a ser armazenado.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <returns>Tarefa que representa a operação assíncrona.</returns>
    Task SetAsync<T>(string key, T value, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Resolve e armazena um valor de forma assíncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="acquire">Função usada para criar o valor.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <returns>Tarefa que representa a operação assíncrona.</returns>
    Task SetAsync<T>(string key, Func<T> acquire, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Armazena um valor de forma síncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="value">Valor a ser armazenado.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    void Set<T>(string key, T value, int? cacheTime = null)
        where T : notnull;

    /// <summary>
    /// Resolve e armazena um valor de forma síncrona.
    /// </summary>
    /// <param name="key">Chave do item.</param>
    /// <param name="acquire">Função usada para criar o valor.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    void Set<T>(string key, Func<T> acquire, int? cacheTime = null)
        where T : notnull;

    /// <summary>Obtém um valor do cache ou o cria de forma assíncrona.</summary>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <param name="key">Chave do item.</param>
    /// <param name="acquireAsync">Função usada para criar o valor caso ele não exista no cache.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <returns>O valor obtido ou criado.</returns>
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>>? acquireAsync = null, int? cacheTime = null);

    /// <summary>Obtém um valor do cache ou o cria.</summary>
    /// <typeparam name="T">Tipo do valor armazenado.</typeparam>
    /// <param name="key">Chave do item.</param>
    /// <param name="acquire">Função usada para criar o valor caso ele não exista no cache.</param>
    /// <param name="cacheTime">Tempo de expiração em segundos.</param>
    /// <returns>O valor obtido ou criado.</returns>
    T? GetOrSet<T>(string key, Func<T>? acquire = null, int? cacheTime = null);

    /// <summary>Remove um valor do cache de forma assíncrona.</summary>
    /// <param name="key">Chave do item.</param>
    /// <returns>Tarefa que representa a operação assíncrona.</returns>
    Task RemoveAsync(string key);

    /// <summary>Remove um valor do cache.</summary>
    /// <param name="key">Chave do item.</param>
    void Remove(string key);
}