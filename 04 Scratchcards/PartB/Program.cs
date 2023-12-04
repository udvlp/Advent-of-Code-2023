namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> copies = new Dictionary<int, int>();
            var sr = new StreamReader(@"..\..\input.txt");
            int result = 0;
            int card = 1;
            while (!sr.EndOfStream)
            {
                copies.TryAdd(card, 0);
                var line = sr.ReadLine();
                var seg = line.Split(new char[] { ':', '|' }, StringSplitOptions.TrimEntries);
                var elf = seg[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
                var winning = seg[2].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
                int points = 0;
                foreach (var e in elf)
                {
                    if (winning.Contains(e)) points++;
                }
                for (int i = 1; i <= points; i++)
                {
                    copies.TryAdd(card + i, 0);
                    copies[card + i] += copies[card] + 1;
                }
                card++;
            }
            foreach (var c in copies)
            {
                if (c.Key < card)
                {
                    Console.WriteLine($"{c.Key} {c.Value}");
                    result += c.Value + 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}