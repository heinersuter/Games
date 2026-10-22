using Battleships.Infrastructure;

namespace Battleships.GamePlay;

public interface IPlayer
{
    void PlaceShips(Grid ownGrid);
}