namespace Battleships.Infrastructure;

public class Cell(int x, int y)
{
    public char Column { get; } = (char)('A' + x);
    
    public int Row { get; } = y + 1;
    
    public string Name => $"{Column}{Row}";
    
    public CellStatus Status { get; set; } = CellStatus.Unknown;
}