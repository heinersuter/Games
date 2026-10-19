using TicTacToe.Material;

namespace TicTacToe.GamePlay.Players;

public interface IPlayer
{
    Wert Wert { get; set; }

    void MacheZug(Board board);
}