using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Abstractions.Web.Module;

/// <summary>
/// Define a interface para a definição de um módulo, permitindo a configuração de serviços,
/// do pipeline de aplicação e o mapeamento de endpoints.
/// </summary>
public interface IModuleDefinition
{
    /// <summary>
    /// Adiciona os serviços específicos do módulo à coleção de serviços.
    /// </summary>
    /// <param name="services">A coleção de serviços.</param>
    /// <param name="configuration">A configuração da aplicação.</param>
    /// <param name="environment">O ambiente de hospedagem web.</param>
    void AddModuleServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment);

    /// <summary>
    /// Configura o pipeline de aplicação para o módulo.
    /// </summary>
    /// <param name="app">O construtor de aplicação.</param>
    /// <param name="configuration">A configuração da aplicação.</param>
    /// <param name="logger">O logger para o módulo.</param>
    /// <param name="environment">O ambiente de hospedagem web.</param>
    /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
    Task ConfigureModule(
        IApplicationBuilder app,
        IConfiguration configuration,
        ILogger logger,
        IWebHostEnvironment environment);

    /// <summary>
    /// Mapeia os endpoints específicos do módulo.
    /// </summary>
    /// <param name="endpoints">O construtor de rotas de endpoint.</param>
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}
