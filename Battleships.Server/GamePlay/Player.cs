using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class Player
{
    public required string Name { get; init; }

    public required Guid Secret { get; set; }

    public required Grid Grid { get; init; }
}

