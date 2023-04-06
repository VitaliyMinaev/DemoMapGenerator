namespace MapGenerator.Domain;

public class Edge
{
    public Planet From { get; }
    public Planet To { get; }

    public Edge(Planet from, Planet to)
    {
        From = from;
        To = to;
    }

    public override string ToString()
    {
        return $"{From.Name} -> {To.Name}";
    }
}