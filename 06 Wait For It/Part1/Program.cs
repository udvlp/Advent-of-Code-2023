namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            var time = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Skip(1).Select(int.Parse).ToList();
            var dist = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Skip(1).Select(int.Parse).ToList();
            int result = 1;
            for (int i = 0; i < time.Count; i++)
            {
                int t = time[i];
                int d = dist[i];
                int c = 0;
                for (int b = 1; b < t; b++)
                {
                    int m = b * (t - b);
                    if (m > d) c++;
                }
                result *= c;
            }
            Console.WriteLine(result);
        }
    }
}