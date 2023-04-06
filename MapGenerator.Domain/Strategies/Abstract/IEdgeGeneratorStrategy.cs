namespace MapGenerator.Domain.Strategies.Abstract;

public interface IEdgeGeneratorStrategy
{
    void GenerateEdges(List<Planet> planets);
}