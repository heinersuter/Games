using Microsoft.AspNetCore.Mvc;

namespace Battleships.Server.GamePlay;

[ApiController]
[Route("game/join")]
public class PostGameJoinController(GameStore gameStore) : ControllerBase
{
    [HttpPost]
    public ActionResult<GameDto?> PostGameJoin(PostGameJoinRequest request)
    {
        var player = gameStore.Game.AddPlayer(request.PlayerName);
        if (player != null)
        {
            return gameStore.Game.Map(player.Secret);
        }

        return BadRequest();
    }
}