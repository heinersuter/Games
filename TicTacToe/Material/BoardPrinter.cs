namespace TicTacToe.Material;

public static class BoardPrinter
{
    public static void Print(Board board)
    {
        Console.WriteLine();
        Console.WriteLine("    A   B   C  ");
        Console.WriteLine("  -------------");
        Console.WriteLine($"1 | {GetChar(board.Felder[Feld.A1])} | {GetChar(board.Felder[Feld.B1])} | {GetChar(board.Felder[Feld.C1])} |");
        Console.WriteLine("  -------------");
        Console.WriteLine($"2 | {GetChar(board.Felder[Feld.A2])} | {GetChar(board.Felder[Feld.B2])} | {GetChar(board.Felder[Feld.C2])} |");
        Console.WriteLine("  -------------");
        Console.WriteLine($"3 | {GetChar(board.Felder[Feld.A3])} | {GetChar(board.Felder[Feld.B3])} | {GetChar(board.Felder[Feld.C3])} |");
        Console.WriteLine("  -------------");
        Console.WriteLine();

        if (board.Sieger != null)
        {
            Console.WriteLine($"Spieler {board.Sieger} hat gewonnen! ☺️");
            Console.WriteLine();
        }
    }

    private static char GetChar(Wert? wert)
    {
        if (wert == Wert.X)
        {
            return 'X';
        }

        if (wert == Wert.O)
        {
            return 'O';
        }

        return ' ';
    }
}