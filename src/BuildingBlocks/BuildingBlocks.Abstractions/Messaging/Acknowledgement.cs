namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Classe base para tipos de confirmação de mensagem (acknowledgement).
/// </summary>
public abstract class Acknowledgement
{
}

/// <summary>
/// Representa uma confirmação positiva (Acknowledge).
/// </summary>
public class Ack : Acknowledgement
{
}

/// <summary>
/// Representa uma confirmação negativa (Negative Acknowledge) com uma exceção.
/// </summary>
public class Nack : Acknowledgement
{
    /// <summary>
    /// Inicializa uma nova instância de <see cref="Nack"/>.
    /// </summary>
    /// <param name="exception">A exceção que causou o Nack.</param>
    /// <param name="requeue">Indica se a mensagem deve ser reenfileirada.</param>
    public Nack(Exception exception, bool requeue = true)
    {
        Requeue = requeue;
        Exception = exception;
    }

    /// <summary>
    /// Obtém um valor que indica se a mensagem deve ser reenfileirada.
    /// </summary>
    public bool Requeue { get; }

    /// <summary>
    /// Obtém a exceção que causou o Nack.
    /// </summary>
    public Exception Exception { get; }
}

/// <summary>
/// Representa uma rejeição da mensagem.
/// </summary>
public class Reject : Acknowledgement
{
    /// <summary>
    /// Obtém um valor que indica se a mensagem deve ser reenfileirada.
    /// </summary>
    public bool Requeue { get; }

    /// <summary>
    /// Inicializa uma nova instância de <see cref="Reject"/>.
    /// </summary>
    /// <param name="requeue">Indica se a mensagem deve ser reenfileirada.</param>
    public Reject(bool requeue = true)
    {
        Requeue = requeue;
    }
}
