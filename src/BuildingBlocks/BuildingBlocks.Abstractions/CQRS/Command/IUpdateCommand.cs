using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando para atualizar uma entidade ou recurso, sem valor de retorno.
/// </summary>
public interface IUpdateCommand : IUpdateCommand<Unit>
{
}

/// <summary>
/// Define um comando para atualizar uma entidade ou recurso, com um valor de retorno.
/// </summary>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface IUpdateCommand<out TResponse> : ICommand<TResponse>
    where TResponse : notnull
{
}
