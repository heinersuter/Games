namespace TicTacToe.Material;

public static class SiegerPrüfung
{
    public static Wert? PrüfeSieger(Board board)
    {
        if (PrüfeSieger(board, Wert.X))
        {
            return Wert.X;
        }

        if (PrüfeSieger(board, Wert.O))
        {
            return Wert.O;
        }

        return null;
    }
    
    private static bool PrüfeSieger(Board board, Wert wert)
    {
        return board.Felder
            .AlleLinien()
            .Any(linie => linie
                .All(feld => feld.Value == wert));
  }
}