using BuildingBlocks.Abstractions.Persistence;
using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando transacional para atualizar uma entidade ou recurso, com um valor de retorno.
/// </summary>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface ITxUpdateCommand<out TResponse> : IUpdateCommand<TResponse>, ITxRequest
    where TResponse : notnull
{
}

/// <summary>
/// Define um comando transacional para atualizar uma entidade ou recurso, sem valor de retorno.
/// </summary>
public interface ITxUpdateCommand : ITxUpdateCommand<Unit>
{
}
