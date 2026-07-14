using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando sem valor de retorno, servindo como um marcador para o MediatR.
/// </summary>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Define um comando com um valor de retorno, herdando de IRequest do MediatR.
/// </summary>
/// <typeparam name="T">O tipo do valor de retorno.</typeparam>
public interface ICommand<out T> : IRequest<T>
    where T : notnull
{
}
