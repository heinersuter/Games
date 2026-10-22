namespace Battleships.Server.GamePlay;

public class ShipDto
{
    public required int Length { get; init; }
    
    public required IEnumerable<CellLocationDto> Cells { get; init; }
}