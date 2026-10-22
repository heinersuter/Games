using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class Game
{
    private readonly Lock _playerLock = new();

    public GameStatus Status { get; set; } = GameStatus.WaitingForPlayers;

    public Player? Player1 { get; private set; }

    public Player? Player2 { get; private set; }
    
    public IEnumerable<ShipRequirement> Ships { get; set; } = new List<ShipRequirement>
    {
        new() { Size = 4 },
        new() { Size = 4 },
        new() { Size = 4 },
        new() { Size = 4 },
        new() { Size = 3 },
        new() { Size = 3 },
        new() { Size = 3 },
        new() { Size = 2 },
        new() { Size = 2 },
        new() { Size = 1 },
    };

    public Player? AddPlayer(string playerName)
    {
        lock (_playerLock)
        {
            if (Player1 == null)
            {
                Player1 = new Player
                {
                    Name = playerName,
                    Secret = Guid.NewGuid(),
                    Grid = new Grid(),
                };
                return Player1;
            }

            if (Player2 == null && Player1.Name != playerName)
            {
                Player2 = new Player
                {
                    Name = playerName,
                    Secret = Guid.NewGuid(),
                    Grid = new Grid(),
                };
                Status = GameStatus.PlacingShips;
                return Player2;
            }

            return null;
        }
    }
    
    public Player? GetOwnPlayer(Guid playerSecret)
    {
        if (Player1?.Secret == playerSecret)
        {
            return Player1;
        }

        if (Player2?.Secret == playerSecret)
        {
            return Player2;
        }

        return null;
    }
    
    public Player? GetOpponentPlayer(Guid playerSecret)
    {
        if (Player1?.Secret != playerSecret)
        {
            return Player1;
        }

        if (Player2?.Secret != playerSecret)
        {
            return Player2;
        }

        return null;
    }
}