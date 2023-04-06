using MapGenerator.Domain.Strategies.EdgesGeneration.Abstract;

namespace MapGenerator.Domain.Strategies.EdgesGeneration;

public class RandomEdgesGeneratorStrategy : IEdgeGeneratorStrategy
{
    public void GenerateEdges(List<Planet> planets)
    {
        foreach (var planet in planets)
        {
            foreach (var localPlanet in planets)
            {
                if (planet.Name == localPlanet.Name)
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
}