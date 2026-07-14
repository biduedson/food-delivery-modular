using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define um manipulador para uma consulta que retorna um resultado.
/// </summary>
/// <typeparam name="TQuery">O tipo da consulta.</typeparam>
/// <typeparam name="TResponse">O tipo da resposta.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}

/// <summary>
/// Define um manipulador para uma consulta que retorna um stream de resultados.
/// </summary>
/// <typeparam name="TQuery">O tipo da consulta.</typeparam>
/// <typeparam name="TResponse">O tipo dos itens no stream.</typeparam>
public interface IStreamQueryHandler<in TQuery, TResponse> : IStreamRequestHandler<TQuery, TResponse>
    where TQuery : IStreamQuery<TResponse>
    where TResponse : notnull
{
}
