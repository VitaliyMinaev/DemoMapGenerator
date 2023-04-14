using MapGenerator.Domain.Models;

namespace MapGenerator.Domain.Strategies;

public interface IMapGenerator
{ 
    Map GenerateMap(MapGenerationOptions options);
}