namespace AoC
{
    internal class Program
    {
        private static Dictionary<(int, int), List<int>> gearmap = new();
        private static int xmax;
        private static int ymax;
        private static string[] lines;

        private static void AddGear(int y, int x, int num)
        {
            if (x >= 0 && x <= xmax && y >= 0 && y <= ymax && lines[y][x] == '*')
            {
                gearmap.TryAdd((y, x), new());
                gearmap[(y, x)].Add(num);
            }
        }

        static void Main(string[] args)
        {
            lines = File.ReadAllLines(@"..\..\input.txt");
            ymax = lines.Length - 1;
            int result = 0;
            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                xmax = line.Length - 1;
                for (int x = 0; x <= xmax; x++)
                {
                    if (line[x] >= '0' && line[x] <= '9')
                    {
                        int num = 0;
                        int x1 = x;
                        while (x <= xmax && line[x] >= '0' && line[x] <= '9')
                        {
                            num = num * 10 + (line[x] - '0');
                            x++;
                        }
                        int x2 = x - 1;

                        AddGear(y, x1 - 1, num);
                        AddGear(y, x2 + 1, num);
                        for (int i = Math.Max(0, x1 - 1); i <= Math.Min(xmax, x2 + 1); i++)
                        {
                            AddGear(y - 1, i, num);
                            AddGear(y + 1, i, num);
                        }
                    }
                }
            }

            foreach (var gear in gearmap)
            {
                if (gear.Value.Count == 2)
                {
                    Console.WriteLine($"Gear {gear.Key} {gear.Value[0]}*{gear.Value[1]}={gear.Value[0] * gear.Value[1]}");
                    result += gear.Value[0] * gear.Value[1];
                }
            }

            Console.WriteLine(result);
        }
    }
}