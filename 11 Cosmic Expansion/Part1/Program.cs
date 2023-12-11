namespace AoC;

internal class Program
{
    static void Main(string[] args)
    {
        var lines = File.ReadAllLines(@"..\..\input.txt");
        int xcount = lines[0].Length;
        int ycount = lines.Length;
        var galaxies = new List<(int x, int y)>();
        var emptycol = new List<int>();
        var emptyrow = new List<int>();
        for (int y = 0; y < ycount; y++)
        {
            bool empty = true;
            for (int x = 0; x < xcount; x++)
            {
                if (lines[y][x] == '#')
                {
                    galaxies.Add((x, y));
                    empty = false;
                }
            }
            if (empty)
            {
                emptyrow.Add(y);
            }
        }
        for (int x = 0; x < xcount; x++)
        {
            bool empty = true;
            for (int y = 0; y < ycount; y++)
            {
                if (lines[y][x] == '#')
                {
                    empty = false;
                }
            }
            if (empty)
            {
                emptycol.Add(x);
            }
        }

        long result = 0;

        for (int i = 0; i < galaxies.Count; i++)
        {
            for (int j = 0; j < galaxies.Count; j++)
            {
                if (i >= j) continue;
                var a = galaxies[i];
                var b = galaxies[j];
                int dx = Math.Abs(b.x - a.x);
                int dy = Math.Abs(b.y - a.y);
                foreach (var k in emptycol)
                {
                    if (k > Math.Min(a.x, b.x) && k < Math.Max(a.x, b.x))
                    {
                        dx++;
                    }
                }
                foreach (var k in emptyrow)
                {
                    if (k > Math.Min(a.y, b.y) && k < Math.Max(a.y, b.y))
                    {
                        dy++;
                    }
                }
                // Console.WriteLine($"Galaxies {i + 1} and {j + 1}: {dx + dy}");
                result += dx + dy;
            }
        }

        Console.WriteLine(result);
    }
}