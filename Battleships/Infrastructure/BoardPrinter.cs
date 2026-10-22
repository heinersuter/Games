namespace Battleships.Infrastructure;

public static class BoardPrinter
{
    extension(Board board)
    {
        public void Print()
        {
            ICollection<string> ownGridLines = ["My Grid:", .. board.Player1Grid.ToLines()];
            ICollection<string> opponentGridLines = ["Opponent's Grid:", ..board.Player2Grid.ToLines()];

            ownGridLines = PadLinesToMaxLength(ownGridLines);
            opponentGridLines = PadLinesToMaxLength(opponentGridLines);

            if (ownGridLines.Count != opponentGridLines.Count)
            {
                throw new InvalidOperationException("The grids must contain the same number of lines.");
            }

            var combinedGridLines = ownGridLines
                .Zip(opponentGridLines, (ownLine, opponentLine) => $"{ownLine}    {opponentLine}");

            foreach (var line in combinedGridLines)
            {
                Console.WriteLine(line);
            }
        }
    }

    private static ICollection<string> PadLinesToMaxLength(ICollection<string> lines)
    {
        var maxLength = lines.Max(line => line.Length);
        return lines
            .Select(line => line.PadRight(maxLength))
            .ToList();
    }
}