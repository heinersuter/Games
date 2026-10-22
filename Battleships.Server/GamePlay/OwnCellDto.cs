using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class OwnCellDto
{
    public required CellLocationDto Location { get; init; }
    
    public required CellStatus Status { get; init; }
}