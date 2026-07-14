using MediatR;

namespace BuildingBlocks.Abstractions.CQRS.Query;

/// <summary>
/// Define uma consulta (query) que retorna um resultado.
/// </summary>
/// <typeparam name="T">O tipo do resultado.</typeparam>
public interface IQuery<out T> : IRequest<T>
    where T : notnull
{
}

/// <summary>
/// Define uma consulta (query) que retorna um stream de resultados.
/// </summary>
/// <typeparam name="T">O tipo dos itens no stream.</typeparam>
public interface IStreamQuery<out T> : IStreamRequest<T>
    where T : notnull
{
}
