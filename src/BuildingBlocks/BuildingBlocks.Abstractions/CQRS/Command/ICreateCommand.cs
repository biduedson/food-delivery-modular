namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando para criar uma entidade ou recurso, com um valor de retorno.
/// </summary>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface ICreateCommand<out TResponse> : ICommand<TResponse>
    where TResponse : notnull
{
}

/// <summary>
/// Define um comando para criar uma entidade ou recurso, sem valor de retorno.
/// </summary>
public interface ICreateCommand : ICommand
{
}
