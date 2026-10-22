using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay.ShipPlacement;

public static class ShipPlacementValidator
{
    public static string? ValidateShips(
        ICollection<ShipRequirement> shipRequirements,
        ICollection<ShipDto> ships)
    {
        var countBySizeError = ValidateCountBySize(shipRequirements, ships);
        if (countBySizeError != null)
        {
            return countBySizeError;
        }

        var invalidShip = ships.FirstOrDefault(ship => ship.Cells.Count() != ship.Size);
        if (invalidShip != null)
        {
            return $"Ship of size {invalidShip.Size} must have exactly {invalidShip.Size} cells";
        }

        var cellsInLinesError = ValidateCellsInLines(ships);
        if (cellsInLinesError != null)
        {
            return cellsInLinesError;
        }

        var spacingError = ValidateSpacing(ships);
        if (spacingError != null)
        {
            return spacingError;
        }

        return null;
    }

    private static string? ValidateCountBySize(ICollection<ShipRequirement> shipRequirements, ICollection<ShipDto> ships)
    {
        var requiredShipSizes = shipRequirements.Select(ship => ship.Size).OrderBy(size => size).ToList();
        var submittedShipSizes = ships.Select(ship => ship.Size).OrderBy(size => size).ToList();

        if (!requiredShipSizes.SequenceEqual(submittedShipSizes))
        {
            return "The ship sizes do not match the requirements";
        }

        return null;
    }

    private static string? ValidateCellsInLines(ICollection<ShipDto> ships)
    {
        foreach (var ship in ships)
        {
            var rows = ship.Cells.Select(cell => cell.Row).Distinct().OrderBy(r => r).ToList();
            var columns = ship.Cells.Select(cell => cell.Column).Distinct().OrderBy(c => c).ToList();

            if (rows.Count > 1 && columns.Count > 1)
            {
                return $"Ship of size {ship.Size} must be placed in a straight line";
            }

            if (rows.Count == 1)
            {
                for (var i = 0; i < columns.Count - 1; i++)
                {
                    if (columns[i + 1] != columns[i] + 1)
                    {
                        return $"Ship of size {ship.Size} must be placed in consecutive cells";
                    }
                }
            }
            else if (columns.Count == 1)
            {
                for (var i = 0; i < rows.Count - 1; i++)
                {
                    if (rows[i + 1] != rows[i] + 1)
                    {
                        return $"Ship of size {ship.Size} must be placed in consecutive cells";
                    }
                }
            }
        }

        return null;
    }

    private static string? ValidateSpacing(ICollection<ShipDto> ships)
    {
        for (var firstShipIndex = 0; firstShipIndex < ships.Count; firstShipIndex++)
        {
            var firstShip = ships.ElementAt(firstShipIndex);

            for (var secondShipIndex = firstShipIndex + 1; secondShipIndex < ships.Count; secondShipIndex++)
            {
                var secondShip = ships.ElementAt(secondShipIndex);

                if (firstShip.Cells.Any(firstCell =>
                        secondShip.Cells.Any(secondCell =>
                            Math.Abs(firstCell.Row - secondCell.Row) <= 1 &&
                            Math.Abs(firstCell.Column - secondCell.Column) <= 1)))
                {
                    return "Ships must not be placed adjacent to one another";
                }
            }
        }

        return null;
    }
}