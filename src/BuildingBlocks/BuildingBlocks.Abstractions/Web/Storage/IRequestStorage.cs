namespace BuildingBlocks.Abstractions.Web.Storage;

/// <summary>
/// Define uma interface para armazenar e recuperar dados no contexto de uma requisição.
/// </summary>
public interface IRequestStorage
{
    /// <summary>
    /// Armazena um valor associado a uma chave na memória de armazenamento da requisição.
    /// </summary>
    /// <typeparam name="T">O tipo do valor a ser armazenado, que não deve ser nulo.</typeparam>
    /// <param name="key">A chave para associar ao valor.</param>
    /// <param name="value">O valor a ser armazenado.</param>
    void Set<T>(string key, T value)
        where T : notnull;
    /// <summary>
    /// Recupera um valor associado a uma chave da memória de armazenamento da requisição.
    /// </summary>
    /// <typeparam name="T">O tipo do valor a ser recuperado.</typeparam>
    /// <param name="key">A chave do valor a ser recuperado.</param>
    /// <returns>O valor recuperado, ou null se a chave não for encontrada ou o tipo não corresponder.</returns>
    T? Get<T>(string key);
}
