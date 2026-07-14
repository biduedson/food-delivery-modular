using BuildingBlocks.Abstractions.Persistence;
using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando transacional para criar uma entidade ou recurso, com um valor de retorno.
/// </summary>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface ITxCreateCommand<out TResponse> : ICommand<TResponse>, ITxRequest
    where TResponse : notnull
{
}

/// <summary>
/// Define um comando transacional para criar uma entidade ou recurso, sem valor de retorno.
/// </summary>
public interface ITxCreateCommand : ITxCreateCommand<Unit>
{
}
