using MapGenerator.Domain.Strategies.EdgesGeneration.Abstract;

namespace MapGenerator.Domain.Strategies.EdgesGeneration;

public class SequentialEdgesGeneratorStrategy : IEdgeGeneratorStrategy
{
    public void GenerateEdges(List<Planet> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if (i + 1 == planets.Count)
                break;

            planets[i].Connect(planets[i + 1]);

            if (i != 0)
            {
                planets[i].Connect(planets[i - 1]);
            }
        }
    }
}