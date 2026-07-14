using MediatR;

namespace BuildingBlocks.Abstractions.Scheduling;

/// <summary>
/// Define um agendador para enfileirar e agendar requisições MediatR.
/// </summary>
public interface IScheduler
{
    /// <summary>
    /// Enfileira uma requisição para execução imediata.
    /// </summary>
    /// <typeparam name="T">O tipo da requisição, que deve ser uma classe e implementar <see cref="IRequest"/>.</typeparam>
    /// <param name="request">A requisição a ser enfileirada.</param>
    void Enqueue<T>(T request)
        where T : class, IRequest;

    /// <summary>
    /// Enfileira uma requisição para execução imediata.
    /// </summary>
    /// <param name="request">A requisição a ser enfileirada.</param>
    void Enqueue(object request);

    /// <summary>
    /// Agenda uma requisição para ser executada em um horário específico.
    /// </summary>
    /// <typeparam name="T">O tipo da requisição, que deve ser uma classe e implementar <see cref="IRequest"/>.</typeparam>
    /// <param name="request">A requisição a ser agendada.</param>
    /// <param name="scheduleAt">O <see cref="DateTimeOffset"/> em que a requisição deve ser executada.</param>
    void Schedule<T>(T request, DateTimeOffset scheduleAt)
        where T : class, IRequest;

    /// <summary>
    /// Agenda uma requisição para ser executada em um horário específico.
    /// </summary>
    /// <param name="request">A requisição a ser agendada.</param>
    /// <param name="scheduleAt">O <see cref="DateTimeOffset"/> em que a requisição deve ser executada.</param>
    void Schedule(object request, DateTimeOffset scheduleAt);

    /// <summary>
    /// Agenda uma requisição para ser executada repetidamente com base em uma expressão CRON.
    /// </summary>
    /// <typeparam name="T">O tipo da requisição, que deve ser uma classe e implementar <see cref="IRequest"/>.</typeparam>
    /// <param name="request">A requisição a ser agendada.</param>
    /// <param name="cornExpression">A expressão CRON que define o padrão de repetição.</param>
    void ScheduleRecurring<T>(T request, string cornExpression)
        where T : class, IRequest;

    /// <summary>
    /// Agenda uma requisição para ser executada repetidamente com base em uma expressão CRON.
    /// </summary>
    /// <param name="request">A requisição a ser agendada.</param>
    /// <param name="cornExpression">A expressão CRON que define o padrão de repetição.</param>
    void ScheduleRecurring(object request, string cornExpression);
}
