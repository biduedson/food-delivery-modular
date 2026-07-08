namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um processador para enviar e agendar comandos.
/// </summary>
public interface ICommandProcessor
{
    /// <summary>
    /// Envia um comando para ser processado imediatamente.
    /// </summary>
    /// <typeparam name="TResult">O tipo do resultado.</typeparam>
    /// <param name="command">O comando a ser enviado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>O resultado do processamento do comando.</returns>
    Task<TResult> SendAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default)
        where TResult : notnull;

    /// <summary>
    /// Agenda um comando interno para processamento em segundo plano.
    /// </summary>
    /// <param name="internalCommand">O comando interno a ser agendado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task ScheduleAsync(IInternalCommand internalCommand, CancellationToken cancellationToken = default);

    /// <summary>
    /// Agenda uma lista de comandos internos para processamento em segundo plano.
    /// </summary>
    /// <param name="internalCommands">Os comandos internos a serem agendados.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    Task ScheduleAsync(IInternalCommand[] internalCommands, CancellationToken cancellationToken = default);
}
