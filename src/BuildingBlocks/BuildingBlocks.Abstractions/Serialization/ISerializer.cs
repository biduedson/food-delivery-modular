namespace BuildingBlocks.Abstractions.Serialization;

/// <summary>
/// Define uma interface para serialização e desserialização de objetos.
/// </summary>
public interface ISerializer
{
    /// <summary>
    /// Obtém o tipo de conteúdo (MIME type) que este serializador manipula.
    /// </summary>
    string ContentType { get; }

    /// <summary>
    /// Serializa o objeto fornecido em uma string.
    /// </summary>
    /// <param name="obj">O objeto a ser serializado.</param>
    /// <param name="camelCase">Indica se as propriedades devem ser serializadas em camelCase.</param>
    /// <param name="indented">Indica se a saída serializada deve ser indentada para legibilidade.</param>
    /// <returns>A representação em string do objeto serializado.</returns>
    string Serialize(object obj, bool camelCase = true, bool indented = true);

    /// <summary>
    /// Desserializa a string fornecida em um objeto do tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">O tipo para o qual a string deve ser desserializada.</typeparam>
    /// <param name="payload">A string a ser desserializada.</param>
    /// <param name="camelCase">Indica se as propriedades na string estão em camelCase.</param>
    /// <returns>O objeto desserializado do tipo <typeparamref name="T"/>, ou null se a desserialização falhar.</returns>
    T? Deserialize<T>(string payload, bool camelCase = true);

    /// <summary>
    /// Desserializa a string fornecida em um objeto do tipo especificado.
    /// </summary>
    /// <param name="payload">A string a ser desserializada.</param>
    /// <param name="type">O <see cref="Type"/> para o qual a string deve ser desserializada.</param>
    /// <param name="camelCase">Indica se as propriedades na string estão em camelCase.</param>
    /// <returns>O objeto desserializado, ou null se a desserialização falhar.</returns>
    object? Deserialize(string payload, Type type, bool camelCase = true);
}
