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
            int result = 0;
            int i = 0;
            string loc = "AAA";
            while (true)
            {
                if (dirs[i] == 'L') loc = map[loc].Item1; else loc = map[loc].Item2;
                result++;
                if (loc == "ZZZ") break;
                i++;
                if (i >= dirs.Length) i = 0;
            }
            Console.WriteLine(result);
        }
    }
}