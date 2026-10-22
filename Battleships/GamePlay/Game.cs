using Battleships.Infrastructure;

namespace Battleships.GamePlay;

public class Game(IPlayer player1, IPlayer player2)
{
    public Board Board { get; set; } = new Board();
    
    public void Start()
    {
        player1.PlaceShips(Board.Player1Grid);
        player2.PlaceShips(Board.Player2Grid);
    }
}