using TicTacToe.Material;

namespace TicTacToe.GamePlay.Players;

public class RandomPlayer() : IPlayer
{
    public Wert Wert { get; set; }

    public void MacheZug(Board board)
    {
        var leereFelder = board.Felder.LeereFelder().Keys.ToList();

        var zufallsIndex = new Random().Next(leereFelder.Count);
        board.SetzeFeld(leereFelder[zufallsIndex], Wert);
    }
}