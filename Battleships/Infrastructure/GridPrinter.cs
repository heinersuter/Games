namespace Battleships.Infrastructure;

public static class GridPrinter
{
    extension(Grid grid)
    {
        public void Print()
        {
            grid.PrintColumnHeaders();

            grid.PrintRows();
        }

        private void PrintColumnHeaders()
        {
            var headers = grid.Cells
                .Select(cell => cell.Column)
                .Distinct()
                .OrderBy(column => column);

            Console.Write("     ");
            Console.Write(string.Join("   ", headers));
            Console.WriteLine();
            
            grid.PrintHorizontalDashes();
        }

        private void PrintRows()
        {
            var cellsByRow = grid.Cells
                .GroupBy(cell => cell.Row)
                .OrderBy(group => group.Key);

            foreach (var row in cellsByRow)
            {
                Console.Write($"{row.Key + 1,2} |");
                foreach (var cell in row)
                {
                    Console.Write($" {CellStatusToSymbol(cell.Status)} |");
                }
                
                Console.WriteLine();
                
                grid.PrintHorizontalDashes();
            }
        }

        private void PrintHorizontalDashes()
        {
            Console.Write("   ");
            Console.WriteLine(new string('-', 4 * grid.Width + 1));
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