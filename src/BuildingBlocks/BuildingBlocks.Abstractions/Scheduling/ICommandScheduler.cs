using BuildingBlocks.Abstractions.CQRS.Command;

namespace BuildingBlocks.Abstractions.Scheduling;

/// <summary>
/// Define um agendador para comandos internos.
/// </summary>
public interface ICommandScheduler
{
    /// <summary>
    /// Agenda um único comando interno para execução.
    /// </summary>
    /// <param name="internalCommand">O comando interno a ser agendado.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ScheduleAsync(
        IInternalCommand internalCommand,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Agenda múltiplos comandos internos para execução.
    /// </summary>
    /// <param name="internalCommandCommands">Um array de comandos internos a serem agendados.</param>
    /// <param name="cancellationToken">Um token para cancelar a operação.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ScheduleAsync(
        IInternalCommand[] internalCommandCommands,
        CancellationToken cancellationToken = default);
}
