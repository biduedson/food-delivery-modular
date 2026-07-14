namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando para deletar uma entidade ou recurso, com um valor de retorno.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
/// <typeparam name="TResponse">O tipo do valor de retorno.</typeparam>
public interface IDeleteCommand<TId, out TResponse> : ICommand<TResponse>
    where TId : struct
    where TResponse : notnull
{
    /// <summary>
    /// O identificador da entidade a ser deletada.
    /// </summary>
    public TId Id { get; init; }
}

/// <summary>
/// Define um comando para deletar uma entidade ou recurso, sem valor de retorno.
/// </summary>
/// <typeparam name="TId">O tipo do identificador.</typeparam>
public interface IDeleteCommand<TId> : ICommand
    where TId : struct
{
    /// <summary>
    /// O identificador da entidade a ser deletada.
    /// </summary>
    public TId Id { get; init; }
}
