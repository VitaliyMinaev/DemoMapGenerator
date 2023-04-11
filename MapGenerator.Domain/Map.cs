using System.Collections;
using System.Collections.Immutable;
using System.Drawing;
using MapGenerator.Domain.Strategies.EdgesFiltration.Abstract;
using MapGenerator.Domain.Strategies.EdgesGeneration.Abstract;

namespace MapGenerator.Domain;

/*
 * x -> 0 ... 100 -> CountOfPlanets = 10 (it can be random)
 * y -> limited from 0 to 30
 */

public class Map : IEnumerable<Planet>
{
    private ICollection<Planet> _planets;
    public IReadOnlyCollection<Planet> Planets { get => _planets.ToImmutableList(); }
    private const int CountOfStage = 1, MinX = 0, MaxX = 1000, CountOfPlanets = 20, MaxY = 300;
    public Map()
    {
        _planets = new List<Planet>();
    }
    public Map(ICollection<Planet> planets)
    {
        _planets = planets;
    }

    public static Map GenerateMap(IEdgeGeneratorStrategy edgeGenerator, IEdgeFilterStrategy edgeFilter)
    {
        var planets = CreatePlanets(MinX, MaxX);
        edgeGenerator.GenerateEdges(planets);
        planets = edgeFilter.Filter(planets);
        
        return new Map(planets);
    }
    private static List<Planet> CreatePlanets(int minX, int maxX)
    {
        const int appropriateDistanceBetweenPlanets = 50;

        var points = new List<Point>();
        var planets = Enumerable.Range(0, CountOfPlanets)
            .Select(x =>
            {
                var currentLocation = new Point(Random.Shared.Next(minX, maxX), Random.Shared.Next(0, MaxY));
                while (true)
                {
                    currentLocation = new Point(Random.Shared.Next(minX, maxX), Random.Shared.Next(0, MaxY));

                    if (points.Any(point =>
                            CalculateDistanceBetweenPoints(point, currentLocation) < appropriateDistanceBetweenPlanets) == false)
                    {
                        points.Add(currentLocation);
                        break;
                    }
                }
                
                return new Planet(currentLocation, $"Planet: #{x}");
            })
            .OrderBy(x => x.Location.X)
            .ToList();

        return planets;
    }

    private static double CalculateDistanceBetweenPoints(Point a, Point b)
    {
        return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
    }
    
    public IEnumerator<Planet> GetEnumerator()
    {
        foreach (var item in _planets)
        {
            yield return item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}