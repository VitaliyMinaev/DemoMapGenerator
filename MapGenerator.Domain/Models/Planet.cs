using MapGenerator.Domain.Models;

namespace MapGenerator.Domain.Models;

public class Planet
{
    public Point Position { get; set; }
    public Planet(Point position)
    {
        Position = position;
    }
}