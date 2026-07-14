namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Coleção de itens de contexto para uma mensagem.
/// </summary>
public class ContextItems
{
    private readonly Dictionary<string, object?> _items = new();

    /// <summary>
    /// Adiciona um item à coleção de contexto.
    /// </summary>
    /// <param name="key">A chave do item.</param>
    /// <param name="value">O valor do item.</param>
    /// <returns>A instância de ContextItems para encadeamento.</returns>
    public ContextItems AddItem(string key, object? value)
    {
        _items.TryAdd(key, value);
        return this;
    }

    /// <summary>
    /// Tenta obter um item da coleção de contexto.
    /// </summary>
    /// <typeparam name="T">O tipo do item.</typeparam>
    /// <param name="key">A chave do item.</param>
    /// <returns>O item, se encontrado e do tipo correto; caso contrário, o valor padrão.</returns>
    public T? TryGetItem<T>(string key)
    {
        if (_items.TryGetValue(key, out var result))
        {
            return result is T type ? type : default;
        }

        return default;
    }
}
