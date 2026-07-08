using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um manipulador para um comando sem valor de retorno.
/// </summary>
/// <typeparam name="TCommand">O tipo do comando.</typeparam>
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

/// <summary>
/// Define um manipulador para um comando com um valor de retorno.
/// </summary>
/// <typeparam name="TCommand">O tipo do comando.</typeparam>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}
