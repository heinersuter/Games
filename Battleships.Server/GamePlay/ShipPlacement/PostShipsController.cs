using Battleships.Server.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Server.GamePlay.ShipPlacement;

[ApiController]
[Route("game/ships")]
public class PostShipsController(GameStore gameStore) : ControllerBase
{
    [HttpPost]
    public ActionResult<GameDto> PostShips(PostShipsRequest request, [FromQuery] Guid playerSecret)
    {
        if (gameStore.Game.Status != GameStatus.PlacingShips)
        {
            return BadRequest("Cannot place ships at this time");
        }
        
        var player = gameStore.Game.GetOwnPlayer(playerSecret);
        if (player == null)
        {
            return NotFound("No player found for the provided secret");
        }
        
        ShipPlacementService.PlaceShips(player.Grid, request.Ships);
        
        var opponent = gameStore.Game.GetOpponentPlayer(playerSecret);
        if (opponent?.Grid.Status == GridStatus.ShipsPlaced)
        {
            gameStore.Game.Status = GameStatus.InBattle;
        }

        return gameStore.Game.Map(playerSecret)!;
    }
}