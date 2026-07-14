namespace BuildingBlocks.Abstractions.Messaging;

/// <summary>
/// Define um contrato para o barramento de mensagens (message bus), que atua como produtor e consumidor.
/// </summary>
public interface IBus : IBusProducer, IBusConsumer
{
    /// <summary>
    /// Inicia o barramento de mensagens.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task StartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Para o barramento de mensagens.
    /// </summary>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task StopAsync(CancellationToken cancellationToken = default);
}
