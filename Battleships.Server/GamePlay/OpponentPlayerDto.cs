namespace Battleships.Server.GamePlay;

public class OpponentPlayerDto
{
    public required string Name { get; init; }
    
    public required OpponentGridDto Grid { get; init; }
}