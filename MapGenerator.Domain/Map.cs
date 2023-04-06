using System.Collections;
using System.Collections.Immutable;
using System.Drawing;

namespace MapGenerator.Domain;

/*
 * x -> 0 ... 100 -> CountOfPlanets = 10 (it can be random)
 * y -> limited from 0 to 30
 */

public class Map : IEnumerable<Planet>
{
    private ICollection<Planet> _planets;
    public IReadOnlyCollection<Planet> Planets { get => _planets.ToImmutableList(); }
    private const int CountOfStage = 1, MinX = 0, MaxX = 1000, CountOfPlanets = 10, MaxY = 300;
    public Map()
    {
        _planets = new List<Planet>();
    }
    public Map(ICollection<Planet> planets)
    {
        _planets = planets;
    }

    public static Map GenerateRandomMap()
    {
        var planets = CreatePlanets(MinX, MaxX);

        GenerateEdgeByOrder(planets);
        
        return new Map(planets);
    }

    private static void GenerateEdgeByOrder(List<Planet> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if(i + 1 == planets.Count)
                break;
            
            int randomValue = Random.Shared.Next(0, 100);
            // 75%
            if (randomValue < 75)
            {
                if (i + 2 >= planets.Count)
                {
                    continue;
                }
                else
                {
                    /* Connect with planet after next planet */
                    planets[i].Connect(planets[i + 2]);

                    if (i != 0)
                    {
                        planets[i].Connect(planets[i - 1]);
                    }
                }
            }
            
            /* Connect with next planet */
            planets[i].Connect(planets[i + 1]);

            if (i != 0)
            {
                planets[i].Connect(planets[i - 1]);
            }
        }
    }
    /// <summary>
    /// Sequential generation
    /// </summary>
    /// <param name="planets"></param>
    private static void GenerateSequentialEdges(List<Planet> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if(i + 1 == planets.Count)
                break;

            planets[i].Connect(planets[i + 1]);

            if (i != 0)
            {
                planets[i].Connect(planets[i - 1]);
            }
        }
    } 
    private static void GenerateRandomEdges(List<Planet> planets)
    {
        foreach (var planet in planets)
        {
            foreach (var localPlanet in planets)
            {
                if(planet.Name == localPlanet.Name)
                    continue;

                if (Random.Shared.Next(0, 100) < 10)
                {
                    planet.Connect(localPlanet);
                }
                if (Random.Shared.Next(0, 100) < 50)
                {
                    localPlanet.Connect(planet);
                }
            }
        }
    }

    private static List<Planet> CreatePlanets(int minX, int maxX)
    {
        return Enumerable.Range(0, CountOfPlanets)
            .Select(x => new Planet(new Point(Random.Shared.Next(minX, maxX), Random.Shared.Next(0, MaxY)),$"Planet: #{x}"))
            .OrderBy(x => x.Location.X)
            .ToList();
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