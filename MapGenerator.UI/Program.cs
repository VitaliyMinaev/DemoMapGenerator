using System.Drawing;
using MapGenerator.Domain;
using System.Drawing.Imaging;
using MapGenerator.Domain.Strategies.EdgesGeneration;
using MapGenerator.Domain.Strategies.EdgesFiltration;

const int width = 1000, height = 300;
const string imageName = "map";
const string extention = ".png";

for (int i = 0; i < 10; i++)
{
    var map = Map.GenerateMap(new SequentialDeepEdgesGeneratorStrategy(), new EdgeFilterStrategy());
    // var map = Map.GenerateMap(new SequentialEdgesGeneratorStrategy());
    // var map = Map.GenerateMap(new RandomEdgesGeneratorStrategy());
    DrawMap(map, i);
}

Console.WriteLine("Bitmaps have been created!");

static void DrawMap(Map map,int number)
{
    var b = new Bitmap(width, height);
    using (Graphics g = Graphics.FromImage(b))
    {
        g.Clear(Color.White);
    
        foreach (var planet in map)
        {
            using (Pen pen = new Pen(Color.Red, 10))
            {
                DrawPoint(planet.Location, g, pen);
            }
        }

        foreach (var planet in map)
        {
            foreach (var edge in planet.Edges)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    DrawLine(edge.From.Location, edge.To.Location, g, pen);
                }
            }
        }
    }

    b.Save($"{imageName}{number}{extention}", ImageFormat.Png);
    b.Dispose();
}
static void DrawPoint(Point point, Graphics g, Pen pen)
{
    g.DrawEllipse(pen, point.X, point.Y, 2, 2);
}
static void DrawLine(Point from, Point to, Graphics g, Pen pen)
{
    g.DrawLine(pen, from, to);
}
static void PrintInfoAboutMap(Map map)
{
    foreach (var planet in map)
    {
        Console.WriteLine(planet);

        foreach (var edge in planet.Edges)
        {
            Console.WriteLine(edge);
        }

        Console.WriteLine("======================================================");
    }
}