namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando interno para processamento assíncrono ou em segundo plano.
/// </summary>
public interface IInternalCommand : ICommand
{
    /// <summary>
    /// O identificador único do comando.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// A data e hora em que o comando ocorreu.
    /// </summary>
    DateTime OccurredOn { get; }

    /// <summary>
    /// O tipo do comando.
    /// </summary>
    string Type { get; }
}
