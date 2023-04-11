using System.Collections.Immutable;
using System.Drawing;

namespace MapGenerator.Domain;

public class Planet
{
    public Point Location { get; private set; }
    public string Name { get; }
    private ICollection<Edge> _edges;
    public IReadOnlyCollection<Edge> Edges { get => _edges.ToImmutableList(); }

    public Planet(Point location, string name)
    {
        Location = location;
        Name = name;
        _edges = new List<Edge>();
    }

    public bool Connect(Planet to)
    {
        if (_edges.Any(x => x.To.Name == to.Name))
            return false;
        
        _edges.Add(new Edge(this, to));
        return true;
    }

    public void ChangeLocation(Point newLocation)
    {
        Location = newLocation;
    }

    public override string ToString()
    {
        return $"Location: {Location}; Name: {Name}";
    }
}