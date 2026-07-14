using Microsoft.AspNetCore.Routing;

namespace BuildingBlocks.Abstractions.Web.MinimalApi;

/// <summary>
/// Define uma interface para a definição de endpoints mínimos, permitindo o mapeamento de rotas.
/// </summary>
public interface IMinimalEndpointDefinition
{
    /// <summary>
    /// Mapeia os endpoints para o construtor de rotas fornecido.
    /// </summary>
    /// <param name="builder">O construtor de rotas de endpoint.</param>
    /// <returns>O <see cref="IEndpointRouteBuilder"/> com os endpoints mapeados.</returns>
    IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder builder);
}
