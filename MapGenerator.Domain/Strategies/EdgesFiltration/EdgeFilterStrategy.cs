using MapGenerator.Domain.Strategies.EdgesFiltration.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGenerator.Domain.Strategies.EdgesFiltration;

public class EdgeFilterStrategy : IEdgeFilterStrategy
{
    public List<Planet> Filter(List<Planet> planets)
    {
        List<Edge> edges = new List<Edge>();

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
                    edges.Remove(second);
                }
            }
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
        double x1 = first.From.Location.X;
        double y1 = first.From.Location.Y;
        double x2 = first.To.Location.X;
        double y2  = first.To.Location.Y;
        double x3 = second.From.Location.X;
        double y3 = second.From.Location.Y;
        double x4 = second.To.Location.X;
        double y4 = second.To.Location.Y;

        if(x1 > x2) // если начало первой грани левее конца, то свапаем координаты
        {
            (x1, x2) = (x2, x1);
            (y1, y2) = (y2, y1);
        }
        if (x3 > x4) // то же самое для второй
        {
            (x3, x4) = (x4, x3);
            (y3, y4) = (y4, y3);
        }

        double k1,k2;

        if (y1 == y2) k1 = 0;
        else k1 = (y2 - y1) / (x2 - x1);

        if (y3 == y4) k2 = 0;
        else k2 = (y4 - y3) / (x4 - x3);

        if (k1 == k2) return false; // грани параллельны


        double b1 = y1 - k1 * x1;
        double b2 = y3 - k2 * x3;

        double x = (b2 - b1) / (k2 - k1); // икс точки пересечения прямых

        bool isInFirstEdge = x >= x1 && x <= x2; // проверка, принадлежит ли этот икс первой грани
        bool isInSecondEdge = x >= x3 && x <= x4; // повторяем для второй грани

        return isInFirstEdge && isInSecondEdge; // если точка принадлежит обеим граням, то они пересекаются
    }
}
