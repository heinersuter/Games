namespace Battleships.Server.GamePlay;

public class CellLocationDto
{
    public required char Column { get; init; }
    
    public required int Row { get; init; }
}