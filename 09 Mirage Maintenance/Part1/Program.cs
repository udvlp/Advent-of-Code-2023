namespace AoC;

internal class Program
{
    static void Main(string[] args)
    {
        var sr = new StreamReader(@"..\..\input.txt");
        long result = 0;
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var values = line.Split(' ').Select(long.Parse).ToList();

            long sequence(List<long> deltas)
            {
                Console.WriteLine(String.Join(", ", deltas));
                if (deltas.All(d => d == 0)) return 0;
                return deltas[^1] + sequence(deltas.Zip(deltas.Skip(1)).Select(p => p.Second - p.First).ToList());
            }

            var r = sequence(values);
            Console.WriteLine(r);
            result += r;

        }
        Console.WriteLine($"Result: {result}");
    }
}