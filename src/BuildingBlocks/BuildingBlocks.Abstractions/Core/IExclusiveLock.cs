namespace BuildingBlocks.Abstractions.Core;

/// <summary>
/// Define um contrato para um mecanismo de bloqueio exclusivo para controlar o acesso a recursos concorrentes.
/// </summary>
public interface IExclusiveLock : IDisposable
{
    /// <summary>
    /// Adquire um bloqueio exclusivo para o objeto especificado.
    /// </summary>
    /// <param name="obj">O objeto a ser bloqueado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Um objeto que representa o bloqueio adquirido.</returns>
    Task<object> AquireAsync(object obj, CancellationToken cancellationToken = default);

    /// <summary>
    /// Libera o bloqueio exclusivo do objeto especificado.
    /// </summary>
    /// <param name="obj">O objeto a ser liberado.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task ReleaseAsync(object obj);

    /// <summary>
    /// Executa uma ação em um objeto de forma síncrona com bloqueio exclusivo.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto.</typeparam>
    /// <param name="obj">O objeto a ser processado.</param>
    /// <param name="action">A ação a ser executada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    void Execute<T>(T obj, Action<T> action, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executa uma função em um objeto de forma assíncrona com bloqueio exclusivo.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto.</typeparam>
    /// <param name="obj">O objeto a ser processado.</param>
    /// <param name="func">A função a ser executada.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task ExecuteAsync<T>(T obj, Func<T, Task> func, CancellationToken cancellationToken = default);
}
