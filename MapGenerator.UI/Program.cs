using System.Drawing;
using System.Drawing.Imaging;
using MapGenerator.Domain.Models;
using MapGenerator.Domain.Strategies;

const int width = 1000, height = 900;

for (int i = 0; i < 10; i++)
{
    var options = new MapGenerationOptions(width, height, 50, 25, 100);
    var map = new MapGeneratorService().GenerateMap(options);

    try
    {
        DrawMap(map, options, $"map-{i}.png");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}

void DrawMap(Map map, MapGenerationOptions options, string fileName)
{
    Bitmap bmp = new Bitmap(options.Width, options.Height);

    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.Clear(Color.White);
                
        foreach (Planet planet in map.Planets)
        {
            g.FillEllipse(Brushes.Red, planet.Position.X - 5, planet.Position.Y - 5, 10, 10);
        }
        foreach (Edge connection in map.Connections)
        {
            g.DrawLine(Pens.Black, new PointF(connection.From.Position.X, connection.From.Position.Y), 
                new PointF(connection.To.Position.X, connection.To.Position.Y));
        }
    }

    bmp.Save(fileName, ImageFormat.Png);
}