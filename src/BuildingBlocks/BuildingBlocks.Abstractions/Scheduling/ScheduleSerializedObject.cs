namespace BuildingBlocks.Abstractions.Scheduler;

/// <summary>
/// Representa um objeto agendado serializado, contendo informações para desserialização e execução.
/// </summary>
public class ScheduleSerializedObject
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ScheduleSerializedObject"/>.
    /// </summary>
    /// <param name="fullTypeName">O nome completo do tipo do objeto serializado.</param>
    /// <param name="data">Os dados serializados do objeto.</param>
    /// <param name="additionalDescription">Uma descrição adicional para o objeto agendado.</param>
    /// <param name="assemblyName">O nome do assembly onde o tipo do objeto está definido.</param>
    public ScheduleSerializedObject(
        string fullTypeName,
        string data,
        string additionalDescription,
        string assemblyName)
    {
        FullTypeName = fullTypeName;
        Data = data;
        AdditionalDescription = additionalDescription;
        AssemblyName = assemblyName;
    }

    /// <summary>
    /// Obtém o nome completo do tipo do objeto serializado.
    /// </summary>
    public string FullTypeName { get; private set; }
    /// <summary>
    /// Obtém os dados serializados do objeto.
    /// </summary>
    public string Data { get; private set; }
    /// <summary>
    /// Obtém uma descrição adicional para o objeto agendado.
    /// </summary>
    public string AdditionalDescription { get; private set; }
    /// <summary>
    /// Obtém o nome do assembly onde o tipo do objeto está definido.
    /// </summary>
    public string AssemblyName { get; private set; }

    /// <summary>
    /// Retorna uma representação em string do objeto agendado serializado.
    /// </summary>
    /// <returns>Uma string que representa o objeto agendado.</returns>
    public override string ToString()
    {
        var commandName = FullTypeName.Split('.').Last();
        return $"{commandName} {AdditionalDescription}";
    }
}
