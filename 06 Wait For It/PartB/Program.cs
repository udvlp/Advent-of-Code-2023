namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            var t = long.Parse(sr.ReadLine().Split(':')[1].Replace(" ", ""));
            var d = long.Parse(sr.ReadLine().Split(':')[1].Replace(" ", ""));
            long result = 1;
            int c = 0;
            for (long b = 1; b < t; b++)
            {
                long m = b * (t - b);
                if (m > d) c++;
            }
            result *= c;
            Console.WriteLine(result);
        }
    }
}