namespace BuildingBlocks.Abstractions.Persistence.EventStore;

/// <summary>
/// Representa a versão esperada de um stream para controle de concorrência otimista.
/// </summary>
/// <param name="Value">O valor da versão.</param>
public record ExpectedStreamVersion(long Value)
{
    /// <summary>
    /// O stream não deve existir.
    /// </summary>
    public static readonly ExpectedStreamVersion NoStream = new(-1);

    /// <summary>
    /// Desabilita o controle de concorrência otimista.
    /// </summary>
    public static readonly ExpectedStreamVersion Any = new(-2);
}

/// <summary>
/// Representa a posição de leitura em um stream.
/// </summary>
/// <param name="Value">O valor da posição.</param>
public record StreamReadPosition(long Value)
{
    /// <summary>
    /// Inicia a leitura a partir do início do stream.
    /// </summary>
    public static readonly StreamReadPosition Start = new(0L);
}

/// <summary>
/// Representa a posição para truncar um stream.
/// </summary>
/// <param name="Value">O valor da posição.</param>
public record StreamTruncatePosition(long Value);
