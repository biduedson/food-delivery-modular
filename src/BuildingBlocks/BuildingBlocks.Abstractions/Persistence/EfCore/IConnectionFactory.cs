using System.Data;

namespace BuildingBlocks.Abstractions.Persistence.EfCore;

/// <summary>
/// Define um contrato para uma fábrica de conexões de banco de dados.
/// </summary>
public interface IConnectionFactory : IDisposable
{
    /// <summary>
    /// Obtém uma conexão existente ou cria uma nova.
    /// </summary>
    /// <returns>Uma instância de <see cref="IDbConnection"/>.</returns>
    IDbConnection GetOrCreateConnection();
}
