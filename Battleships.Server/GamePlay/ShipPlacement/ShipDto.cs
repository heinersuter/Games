namespace Battleships.Server.GamePlay.ShipPlacement;

public class ShipDto
{
    public required int Size { get; init; }
    
    public required IEnumerable<CellLocationDto> Cells { get; init; }
}