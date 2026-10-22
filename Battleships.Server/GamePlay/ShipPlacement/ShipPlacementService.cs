using Battleships.Server.Infrastructure;

namespace Battleships.Server.GamePlay.ShipPlacement;

public static class ShipPlacementService
{
    public static string? PlaceShips(Grid ownGrid, IEnumerable<ShipDto> ships)
    {
        foreach (var ship in ships)
        {
            foreach (var shipCell in ship.Cells)
            {
                var gridCell = ownGrid.Cells.FirstOrDefault(cell =>
                    cell.Location.Row == shipCell.Row && cell.Location.Column == shipCell.Column);
                
                if (gridCell is not { Status: CellStatus.Water })
                {
                    return $"Invalid ship placement: {shipCell.Column}{shipCell.Row}";
                }

                gridCell.Status = CellStatus.Ship;
            }
        }

        return null;
    }
}