namespace Battleships.Server.Infrastructure;

public enum CellStatus
{
    Water, // Turn to "Unknown" for OpponentsGrid
    Miss,
    Ship, // Turn to "Unknown" for OpponentsGrid
    Hit,
    Sunk,
}