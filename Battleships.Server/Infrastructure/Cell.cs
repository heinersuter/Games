namespace Battleships.Server.Infrastructure;

public class Cell
{
    public required CellLocation Location { get; init; }
    
    public CellStatus Status { get; set; } = CellStatus.Water;
}