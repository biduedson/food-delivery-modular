namespace BuildingBlocks.Abstractions.Persistence;

/// <summary>
/// Define um contrato para popular dados iniciais (seeding) no banco de dados.
/// </summary>
public interface IDataSeeder
{
    /// <summary>
    /// Executa o processo de seeding de todos os dados necessários.
    /// </summary>
    /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
    Task SeedAllAsync();
}
