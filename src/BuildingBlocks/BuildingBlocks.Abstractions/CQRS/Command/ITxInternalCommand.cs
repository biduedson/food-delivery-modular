using BuildingBlocks.Abstractions.Persistence;

namespace BuildingBlocks.Abstractions.CQRS.Command;

/// <summary>
/// Define um comando interno transacional.
/// </summary>
public interface ITxInternalCommand : IInternalCommand, ITxRequest
{
}
