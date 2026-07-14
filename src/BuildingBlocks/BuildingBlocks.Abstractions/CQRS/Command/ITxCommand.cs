using BuildingBlocks.Abstractions.Persistence;
using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando transacional sem valor de retorno.
/// </summary>
public interface ITxCommand : ITxCommand<Unit>
{
}

/// <summary>
/// Define um comando transacional com um valor de retorno.
/// </summary>
/// <typeparam name="T">O tipo do valor de retorno.</typeparam>
public interface ITxCommand<out T> : ICommand<T>, ITxRequest
    where T : notnull
{
}
