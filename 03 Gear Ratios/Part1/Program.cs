namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                        bool symbol = false;
                        if ((x1 > 0 && lines[y][x1 - 1] != '.') || (x2 < xmax && lines[y][x2 + 1] != '.'))
                        {
                            symbol = true;
                        }
                        else
                        {
                            for (int i = Math.Max(0, x1 - 1); i <= Math.Min(xmax, x2 + 1); i++)
                            {
                                if ((y > 0 && lines[y - 1][i] != '.') || (y < ymax && lines[y + 1][i] != '.'))
                                {
                                    symbol = true;
                                    break;
                                }
                            }
                        }

                        Console.WriteLine($"{num} at y:{y} x:{x1}-{x2} {symbol}");
                        if (symbol)
                        {
                            result += num;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}