using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para resolver a fachada do banco de dados (DatabaseFacade) de um DbContext.
/// </summary>
public interface IDbFacadeResolver
{
    /// <summary>
    /// Obtém a instância do <see cref="DatabaseFacade"/>.
    /// </summary>
    DatabaseFacade Database { get; }
}
