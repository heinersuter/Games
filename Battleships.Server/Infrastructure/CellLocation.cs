namespace Battleships.Server.Infrastructure;

public class CellLocation
{
    public required char Column { get; init; }
    
    public required int Row { get; init; }
}