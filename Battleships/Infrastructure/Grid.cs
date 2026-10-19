namespace Battleships.Infrastructure;

public class Grid(int width = 10, int height = 10)
{
    public int Width { get; } = width;
    
    public int Height { get; } = height;
}