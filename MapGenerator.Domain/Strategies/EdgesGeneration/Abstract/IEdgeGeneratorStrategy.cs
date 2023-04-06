namespace MapGenerator.Domain.Strategies.EdgesGeneration.Abstract;

public interface IEdgeGeneratorStrategy
{
    void GenerateEdges(List<Planet> planets);
}