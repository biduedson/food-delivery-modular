namespace BuildingBlocks.Abstractions.Domain;

/// <summary>
/// Define um contrato para entidades que possuem informações de auditoria (criação e modificação).
/// </summary>
public interface IHaveAudit : IHaveCreator
{
    /// <summary>
    /// A data da última modificação.
    /// </summary>
    DateTime? LastModified { get; }

    /// <summary>
    /// O identificador do usuário que realizou a última modificação.
    /// </summary>
    int? LastModifiedBy { get; }
}
