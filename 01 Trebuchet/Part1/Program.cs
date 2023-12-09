using System;
using System.IO;

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
                int num = 0;
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] >= '0' && line[i] <= '9')
                    {
                        num = 10 * (line[i] - '0');
                        break;
                    }
                }
                for (var i = line.Length - 1; i >= 0; i--)
                {
                    if (line[i] >= '0' && line[i] <= '9')
                    {
                        num += (line[i] - '0');
                        break;
                    }
                }
                result += num;
                Console.WriteLine($"{line} {num}");
            }
            Console.WriteLine(result);
        }
    }
}