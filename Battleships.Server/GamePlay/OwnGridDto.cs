namespace Battleships.Server.GamePlay;

public class OwnGridDto
{
    public required IEnumerable<OwnCellDto> Cells { get; init; }
}