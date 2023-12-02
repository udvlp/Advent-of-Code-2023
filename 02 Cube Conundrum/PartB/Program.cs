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
                var min = new Dictionary<string, int>() { { "blue", 0 }, { "green", 0 }, { "red", 0 } };
                foreach (var grab in line!.Split(": ")[1].Split("; "))
                {
                    foreach (var col in grab.Split(", "))
                    {
                        if (col.Split(" ") is [var vs, var n])
                        {
                            int v = int.Parse(vs);
                            if (v > min[n]) min[n] = v;
                        }
                    }
                }
                result += min["blue"] * min["green"] * min["red"];
            }
            Console.WriteLine(result);
        }
    }
}