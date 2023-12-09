using System.Text.RegularExpressions;

namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");

            var dirs = sr.ReadLine();

            Regex regex = new Regex(@"(\w+) = \((\w+), (\w+)\)");
            var map = new Dictionary<string, (string, string)>();
            while (!sr.EndOfStream)
            {
                var m = regex.Match(sr.ReadLine());
                if (m.Success)
                {
                    map.Add(m.Groups[1].Value, (m.Groups[2].Value, m.Groups[3].Value));
                }
            }

            Dictionary<string, int> startlocations = new();
            foreach (var l in map.Keys)
            {
                if (l[2] == 'A') startlocations.Add(l, 0);
            }

            foreach (var startlocation in startlocations.Keys)
            {
                int len = 0;
                string loc = startlocation;
                int i = 0;
                while (true)
                {
                    if (dirs[i] == 'L') loc = map[loc].Item1; else loc = map[loc].Item2;
                    len++;
                    if (loc[2] == 'Z') break;
                    i++;
                    if (i >= dirs.Length) i = 0;
                }
                startlocations[startlocation] = len;
            }

            foreach (var curr in startlocations)
            {
                Console.WriteLine($"{curr.Value}");
            }

            int gcd = 0;
            foreach (var curr in startlocations)
            {
                if (gcd != 0)
                {
                    int num1 = gcd;
                    int num2 = curr.Value;
                    int rem;
                    while (num2 != 0)
                    {
                        rem = num1 % num2;
                        num1 = num2;
                        num2 = rem;
                    }
                    gcd = num1;
                }
                else
                {
                    gcd = curr.Value;
                }
            }

            Console.WriteLine($"GCD: {gcd}");

            long result = gcd;
            foreach (var curr in startlocations)
            {
                Console.WriteLine($"{curr.Value / gcd} {curr.Value % gcd}");
                result *= (curr.Value / gcd);
            }

            Console.WriteLine($"{result}"); // 13289612809129
        }

    }
}