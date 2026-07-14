using MediatR;

namespace BuildingBlocks.Abstractions.Scheduling;

/// <summary>
/// Define um executor para requisições agendadas.
/// </summary>
public interface IScheduleExecutor
{
    /// <summary>
    /// Executa uma requisição agendada.
    /// </summary>
    /// <typeparam name="T">O tipo da requisição, que deve ser uma classe e implementar <see cref="IRequest"/>.</typeparam>
    /// <param name="request">A requisição a ser executada.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task Execute<T>(T request)
        where T : class, IRequest;

    /// <summary>
    /// Executa uma requisição agendada.
    /// </summary>
    /// <param name="request">A requisição a ser executada.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task Execute(object request);
}
