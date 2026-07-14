using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.Persistence.EventStore.Projections;

/// <summary>
/// Define um contrato para uma projeção de leitura (Read Model).
/// </summary>
public interface IHaveReadProjection
{
    /// <summary>
    /// Projeta um evento de stream para atualizar o modelo de leitura.
    /// </summary>
    /// <typeparam name="T">O tipo do evento de domínio.</typeparam>
    /// <param name="streamEvent">O evento de stream a ser projetado.</param>
    /// <param name="cancellationToken">O token de cancelamento.</param>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task ProjectAsync<T>(IStreamEvent<T> streamEvent, CancellationToken cancellationToken = default)
        where T : IDomainEvent;
}
