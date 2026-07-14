namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para entidades que possuem informações de criação.
/// </summary>
public interface IHaveCreator
{
    /// <summary>
    /// A data de criação.
    /// </summary>
    DateTime Created { get; }

    /// <summary>
    /// O identificador do usuário que criou a entidade.
    /// </summary>
    int? CreatedBy { get; }
}
