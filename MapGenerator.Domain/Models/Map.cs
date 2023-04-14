namespace MapGenerator.Domain.Models;
public class Map
{
    public List<Planet> Planets { get; set; }
    public List<Edge> Connections { get; set; }
    public Map(List<Planet> planets, List<Edge> connections)
    {
        Planets = planets;
        Connections = connections;
    }
}