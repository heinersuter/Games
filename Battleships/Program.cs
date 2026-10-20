using Battleships.Infrastructure;

var grid = new Grid();
grid.Cells.First(cell => cell.Name == "A1").Status = CellStatus.Miss;
grid.Print();
