namespace Battleships.Server.GamePlay;

public class OwnPlayerDto
{
    public required string Name { get; init; }
    
    public required Guid? Secret { get; init; }
    
    public required OwnGridDto Grid { get; init; }
}