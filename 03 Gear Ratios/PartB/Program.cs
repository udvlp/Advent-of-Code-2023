namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<(int, int), List<int>> gearmap = new();
            var lines = File.ReadAllLines(@"..\..\input.txt");
            var ymax = lines.Length - 1;
            int result = 0;
            for (int y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                var xmax = line.Length - 1;
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
                        if (x1 > 0 && lines[y][x1 - 1] == '*')
                        {
                            gearmap.TryAdd((y, x1 - 1), new());
                            gearmap[(y, x1 - 1)].Add(num);
                        }

                        if (x2 < xmax && lines[y][x2 + 1] == '*')
                        {
                            gearmap.TryAdd((y, x2 + 1), new());
                            gearmap[(y, x2 + 1)].Add(num);
                        }

                        for (int i = Math.Max(0, x1 - 1); i <= Math.Min(xmax, x2 + 1); i++)
                        {
                            if (y > 0 && lines[y - 1][i] == '*')
                            {
                                gearmap.TryAdd((y - 1, i), new());
                                gearmap[(y - 1, i)].Add(num);
                            }

                            if (y < ymax && lines[y + 1][i] == '*')
                            {
                                gearmap.TryAdd((y + 1, i), new());
                                gearmap[(y + 1, i)].Add(num);
                            }
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