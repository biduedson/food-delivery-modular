using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Abstractions.Web.Module;

/// <summary>
/// Define a interface para a raiz de composição de um módulo, fornecendo acesso ao provedor de serviços
/// e à definição do módulo.
/// </summary>
public interface ICompositionRoot
{
    /// <summary>
    /// Obtém o <see cref="IServiceProvider"/> associado a esta raiz de composição.
    /// </summary>
    IServiceProvider ServiceProvider { get; }
    /// <summary>
    /// Obtém a <see cref="IModuleDefinition"/> associada a esta raiz de composição.
    /// </summary>
    IModuleDefinition ModuleDefinition { get; }
    /// <summary>
    /// Cria um novo escopo de serviço.
    /// </summary>
    /// <returns>Um novo <see cref="IServiceScope"/>.</returns>
    IServiceScope CreateScope();
}
