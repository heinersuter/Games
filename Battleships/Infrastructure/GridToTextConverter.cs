namespace Battleships.Infrastructure;

public static class GridToTextConverter
{
    extension(Grid grid)
    {
        public IEnumerable<string> ToLines()
        {
            foreach (var line in grid.PrintColumnHeaders())
            {
                yield return line;
            }
            
            foreach (var line in grid.PrintRows())
            {
                yield return line;
            }
        }

        private IEnumerable<string> PrintColumnHeaders()
        {
            var headers = grid.Cells
                .Select(cell => cell.Column)
                .Distinct()
                .OrderBy(column => column);

            yield return $"     {string.Join("   ", headers)}  ";
             
            yield return grid.PrintHorizontalDashes();
        }

        private IEnumerable<string> PrintRows()
        {
            var cellsByRow = grid.Cells
                .GroupBy(cell => cell.Row)
                .OrderBy(group => group.Key);

            foreach (var row in cellsByRow)
            {
                var line = $"{row.Key,2} |";
                foreach (var cell in row)
                {
                    line += $" {CellStatusToSymbol(cell.Status)} |";
                }
                
                yield return line;
                
                yield return grid.PrintHorizontalDashes();
            }
        }

        private string PrintHorizontalDashes()
        {
            return $"   {new string('-', 4 * grid.Width + 1)}";
        }
    }
        
    private static char CellStatusToSymbol(CellStatus status)
    {
        return status switch
        {
            CellStatus.Unknown => ' ',
            CellStatus.Miss => '~',
            CellStatus.Hit => 'X',
            CellStatus.Sunk => '#',
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }
}