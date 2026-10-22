using Battleships.Server.GamePlay.ShipPlacement;
using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class GameDto
{
    public required GameStatus Status { get; init; }
    
    public required OwnPlayerDto? You { get; init; }
    
    public required OpponentPlayerDto? Opponent { get; init; }
    
    public required IEnumerable<ShipRequirementDto> Ships { get; init; }
}