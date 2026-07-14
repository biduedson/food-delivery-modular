using BuildingBlocks.Abstractions.CQRS.Event.Internal;

namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para um agregado, que é uma raiz de consistência transacional.
/// </summary>
public interface IHaveAggregate : IHaveAggregateVersion
{
    /// <summary>
    /// Verifica se o agregado possui eventos de domínio não confirmados.
    /// </summary>
    /// <returns>True se houver eventos não confirmados; caso contrário, false.</returns>
    public bool HasUncommittedDomainEvents();

    /// <summary>
    /// Obtém a lista de eventos de domínio não confirmados.
    /// </summary>
    /// <returns>Uma lista somente leitura de eventos de domínio.</returns>
    IReadOnlyList<IDomainEvent> GetUncommittedDomainEvents();

    /// <summary>
    /// Marca os eventos de domínio não confirmados como confirmados.
    /// </summary>
    void MarkUncommittedDomainEventAsCommitted();

    /// <summary>
    /// Verifica uma regra de negócio e lança uma exceção se a regra for violada.
    /// </summary>
    /// <param name="rule">A regra de negócio a ser verificada.</param>
    void CheckRule(IBusinessRule rule);
}
