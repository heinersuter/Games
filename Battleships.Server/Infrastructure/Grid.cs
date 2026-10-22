namespace Battleships.Server.Infrastructure;

public class Grid
{
    private const int Width = 10;

    private const int Height = 10;
    
    public IEnumerable<Cell> Cells { get; }

    public GridStatus Status { get; set; } = GridStatus.Empty;

    public Grid()
    {
        var cells = new List<Cell>();
        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                cells.Add(new Cell{
                    Location = new CellLocation
                    {
                        Column = (char)('A' + x),
                        Row = y + 1,
                    },
                });
            }
        }
        Cells = cells;
    }
}