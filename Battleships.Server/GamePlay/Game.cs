using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public class Game
{
    private readonly Lock _playerLock = new();

    public GameStatus Status { get; set; } = GameStatus.WaitingForPlayers;

    private Player? _player1;

    private Player? _player2;
    
    public IEnumerable<ShipRequirement> Ships { get; set; } = new List<ShipRequirement>
    {
        // new() { Size = 4 },
        // new() { Size = 4 },
        // new() { Size = 4 },
        // new() { Size = 4 },
        // new() { Size = 3 },
        // new() { Size = 3 },
        // new() { Size = 3 },
        // new() { Size = 2 },
        new() { Size = 2 },
        new() { Size = 1 },
    };

    public Player? AddPlayer(string playerName)
    {
        lock (_playerLock)
        {
            if (_player1 == null)
            {
                _player1 = new Player
                {
                    Name = playerName,
                    Secret = Guid.NewGuid(),
                    Grid = new Grid(),
                };
                return _player1;
            }

            if (_player2 == null && _player1.Name != playerName)
            {
                _player2 = new Player
                {
                    Name = playerName,
                    Secret = Guid.NewGuid(),
                    Grid = new Grid(),
                };
                Status = GameStatus.PlacingShips;
                return _player2;
            }

            return null;
        }
    }
    
    public Player? GetOwnPlayer(Guid playerSecret)
    {
        if (_player1?.Secret == playerSecret)
        {
            return _player1;
        }

        if (_player2?.Secret == playerSecret)
        {
            return _player2;
        }

        return null;
    }
    
    public Player? GetOpponentPlayer(Guid playerSecret)
    {
        if (_player1?.Secret != playerSecret)
        {
            return _player1;
        }

        if (_player2?.Secret != playerSecret)
        {
            return _player2;
        }

        return null;
    }
}