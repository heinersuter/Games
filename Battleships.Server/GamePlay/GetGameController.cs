using Microsoft.AspNetCore.Mvc;

namespace Battleships.Server.GamePlay;

[ApiController]
[Route("game")]
public class GetGameController(GameStore gameStore) : ControllerBase
{
    [HttpGet]
    public ActionResult<GameDto> GetGame([FromQuery] Guid playerSecret)
    {
        var game = gameStore.Game.Map(playerSecret);
        
        if (game == null)
        {
            return NotFound();
        }
        
        return game;
    }
}