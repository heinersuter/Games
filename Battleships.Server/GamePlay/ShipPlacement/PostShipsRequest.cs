namespace Battleships.Server.GamePlay.ShipPlacement;

public class PostShipsRequest
{
    public required IEnumerable<ShipDto> Ships { get; init; }
}