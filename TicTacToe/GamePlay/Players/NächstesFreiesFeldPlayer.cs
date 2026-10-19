using TicTacToe.Material;

namespace TicTacToe.GamePlay.Players;

public class NächstesFreiesFeldPlayer() : IPlayer
{
    public Wert Wert { get; set; }
    
    public void MacheZug(Board board)
    {
        var feld = board.Felder.LeereFelder().First();
        board.SetzeFeld(feld.Key, Wert);
    }
}