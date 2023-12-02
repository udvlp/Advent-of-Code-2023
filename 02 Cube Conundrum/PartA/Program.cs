namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sr = new StreamReader(@"..\..\input.txt");
            int result = 0;
            int gamenumber = 1;
            var limits = new Dictionary<string, int>() { { "blue", 14 }, { "green", 13 }, { "red", 12 } };
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                bool possible = true;
                foreach (var grab in line!.Split(": ")[1].Split("; "))
                {
                    foreach (var col in grab.Split(", "))
                    {
                        if (col.Split(" ") is [var vs, var n])
                        {
                            int v = int.Parse(vs);
                            if (v > limits[n])
                            {
                                possible = false;
                                break;
                            }
                        }
                    }
                    if (!possible) break;
                }
                if (possible) result += gamenumber;
                gamenumber++;
            }

            Console.WriteLine(result);
        }
    }
}