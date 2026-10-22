using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay;

public static class GameMapper
{
    extension(Game game)
    {
        public GameDto? Map(Guid playerSecret)
        {
            var you = game.GetOwnPlayer(playerSecret);

            if (you == null)
            {
                return null;
            }

            var opponent = game.GetOpponentPlayer(playerSecret);

            return new GameDto
            {
                Status = game.Status,
                You = you.MapToOwn(),
                Opponent = opponent?.MapToOpponent(),
                Ships = game.Ships.Select(Map),
            };
        }
    }

    extension(ShipRequirement shipRequirement)
    {
        private ShipRequirementDto Map()
        {
            return new ShipRequirementDto
            {
                Length = shipRequirement.Length,
            };
        }
     }

    extension(Player player)
    {
        private OwnPlayerDto MapToOwn()
        {
            return new OwnPlayerDto
            {
                Name = player.Name,
                Secret = player.Secret,
                Grid = player.Grid.MapToOwn(),
            };
        }
        
        private OpponentPlayerDto MapToOpponent()
        {
            return new OpponentPlayerDto
            {
                Name = player.Name,
                Grid = player.Grid.MapToOpponent(),
            };
        }
    }

    extension(Grid grid)
    {
        private OwnGridDto MapToOwn()
        {
            return new OwnGridDto
            {
                Cells = grid.Cells.Select(cell => new OwnCellDto
                {
                    Location = new CellLocationDto
                    {
                        Column = cell.Location.Column,
                        Row = cell.Location.Row,
                    },
                    Status = cell.Status,
                }),
            };
        }
        
        private OpponentGridDto MapToOpponent()
        {
            return new OpponentGridDto
            {
                Cells = grid.Cells.Select(cell => new OpponentCellDto
                {
                    Location = new CellLocationDto
                    {
                        Column = cell.Location.Column,
                        Row = cell.Location.Row,
                    },
                    Status = cell.Status.MapToOpponent(),
                }),
            };
        }
    }

    extension(CellStatus status)
    {
        private OpponentCellStatus MapToOpponent()
        {
            return status switch
            {
                CellStatus.Water or CellStatus.Ship => OpponentCellStatus.Unknown,
                CellStatus.Hit => OpponentCellStatus.Hit,
                CellStatus.Miss => OpponentCellStatus.Miss,
                CellStatus.Sunk => OpponentCellStatus.Sunk,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}