using TicTacToe.Material;

namespace TicTacToe.GamePlay.Players;

public class ConsolePlayer() : IPlayer
{
    public Wert Wert { get; set; }
    
    public void MacheZug(Board board)
    {
        var feldEingegeben = false;
        while (!feldEingegeben)
        {
            Console.Write($"Spieler {Wert}, bitte Feld eingeben: ");
            var text = Console.ReadLine() ?? string.Empty;
            if (Enum.TryParse<Feld>(text.ToUpperInvariant(), out var feld))
            {
                if (board.SetzeFeld(feld, Wert))
                {
                    feldEingegeben = true;
                }
            }
            else
            {
                Console.WriteLine($"{text} ist keine gültige Feldbezeichnung.");
            }
        }
    }
}