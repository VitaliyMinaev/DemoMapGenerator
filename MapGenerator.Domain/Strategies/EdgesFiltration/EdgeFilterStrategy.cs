using MapGenerator.Domain.Strategies.EdgesFiltration.Abstract;
using System.Drawing;

namespace MapGenerator.Domain.Strategies.EdgesFiltration;

public class EdgeFilterStrategy : IEdgeFilterStrategy
{
    public List<Planet> Filter(List<Planet> planets)
    {
        var edges = new List<Edge>();
        var crossingEdges = new List<Edge>();

        foreach (var planet in planets)
        {
            edges.AddRange(planet.Edges);
        }

        foreach (var first in edges)
        {
            foreach(var second in edges)
            {
                var isSameFrom = first.From.Name == second.From.Name;
                var isSameTo = first.To.Name == second.To.Name;
                var isChain = first.From.Name == second.To.Name || first.To.Name == second.From.Name;
                if ((isSameFrom || isSameTo || isChain)) 
                {
                    continue; 
                }

                if(IsCrossing(first, second)) 
                {
                    crossingEdges.Add(second);
                }
            }
        }

        foreach(var edge in crossingEdges)
        {
            edges.Remove(edge);
        }

        List<Planet> planetsWithFilteredEdges = planets.Select(p => new Planet(p.Location,p.Name)).ToList();

        foreach (var edge in edges)
        {
            var from = planetsWithFilteredEdges.First(p => p.Name == edge.From.Name);
            var to = planetsWithFilteredEdges.First(p => p.Name == edge.To.Name);

            from.Connect(to);
        }

        return planetsWithFilteredEdges;
    }

    private bool IsCrossing(Edge first, Edge second)
    {
        var a = first.From.Location;
        var b = first.To.Location;
        var c = second.From.Location;
        var d = second.To.Location;

        return BoundingBox(a.X, b.X, c.X, d.X)
            && BoundingBox(a.Y, b.Y, c.Y, d.Y)
            && OrientedTriangleArea(a, b, c) * OrientedTriangleArea(a, b, d) <= 0
            && OrientedTriangleArea(c, d, a) * OrientedTriangleArea(c, d, b) <= 0;
    }

    private bool BoundingBox(int a, int b, int c, int d)
    {
        if (a > b) (a, b) = (b, a);
        if (c > d) (c, d) = (d, c);

        return Math.Max(a,c) < Math.Min(b, d);
    }

    private int OrientedTriangleArea(Point a, Point b, Point c)
    {
        return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
    }
}
