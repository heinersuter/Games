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
            Console.Write("     ");
            for (var i = 0; i < grid.Width; i++)
            {
                if (i > 0)
                {
                    Console.Write("   ");
                }

                Console.Write((char)('A' + i));
            }
            
            Console.WriteLine();
            
            grid.PrintHorizontalDashes();
        }

        private void PrintRows()
        {
            for (var i = 0; i < grid.Height; i++)
            {
                Console.Write($"{i + 1,2} |");
                for (var j = 0; j < grid.Width; j++)
                {
                    Console.Write("   |");
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
}