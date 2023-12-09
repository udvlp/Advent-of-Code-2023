namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int result = 0;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var seg = line.Split(new char[] { ':', '|' }, StringSplitOptions.TrimEntries);
                var elf = seg[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
                var winning = seg[2].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
                int points = 0;
                foreach (var e in elf)
                {
                    if (winning.Contains(e))
                    {
                        if (points == 0) points = 1; else points *= 2;
                    }
                }
                result += points;
            }
            Console.WriteLine(result);
        }
    }
}