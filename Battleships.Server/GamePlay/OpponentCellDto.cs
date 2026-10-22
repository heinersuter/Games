using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class OpponentCellDto
{
    public required CellLocationDto Location { get; init; }
    
    public required OpponentCellStatus Status { get; init; }
}