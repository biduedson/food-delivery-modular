namespace BuildingBlocks.Abstractions.Types;

/// <summary>
/// Define uma interface para obter informações da instância da máquina.
/// </summary>
public interface IMachineInstanceInfo
{
    /// <summary>
    /// Obtém o grupo de clientes ao qual a instância pertence.
    /// </summary>
    string ClientGroup { get; }
    /// <summary>
    /// Obtém o identificador único da instância do cliente.
    /// </summary>
    Guid ClientId { get; }
}
