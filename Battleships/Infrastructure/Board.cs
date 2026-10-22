namespace Battleships.Infrastructure;

public class Board
{
    public Grid Player1Grid { get; } = new();
    
    public Grid Player2Grid { get; } = new();
}