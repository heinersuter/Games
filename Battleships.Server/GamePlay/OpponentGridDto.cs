namespace Battleships.Server.GamePlay;

public class OpponentGridDto
{
    public required IEnumerable<OpponentCellDto> Cells { get; init; }
}