using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.Persistence.EventStore.Projections;

/// <summary>
/// Define um contrato para um publicador de projeções de leitura.
/// </summary>
public interface IReadProjectionPublisher
{
    /// <summary>
    /// Publica um evento de stream para ser projetado.
    /// </summary>
    /// <param name="streamEvent">O evento de stream a ser publicado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync(IStreamEvent streamEvent, CancellationToken cancellationToken = default);

    /// <summary>
    /// Publica um evento de stream com tipo de dado específico para ser projetado.
    /// </summary>
    /// <typeparam name="T">O tipo do evento de domínio.</typeparam>
    /// <param name="streamEvent">O evento de stream a ser publicado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task PublishAsync<T>(IStreamEvent<T> streamEvent, CancellationToken cancellationToken = default)
        where T : IDomainEvent;
}
