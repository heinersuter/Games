namespace Battleships.Infrastructure;

public class Grid
{
    public Grid(int width = 10, int height = 10)
    {
        Width = width;
        Height = height;

        var cells = new List<Cell>();
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
            {
                cells.Add(new Cell(i, j));
            }
        }
        Cells = cells;
    }

    public int Width { get; }
    
    public int Height { get; }
    
    public IEnumerable<Cell> Cells { get; }
}