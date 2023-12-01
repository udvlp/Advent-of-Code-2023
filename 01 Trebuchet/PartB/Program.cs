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
            string[] digits = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                int num = 0;

                int firstindex = line.Length;
                int lastindex = 0;

                int digitvalue = 1;
                foreach (var dig in digits)
                {
                    int foundindex = line.IndexOf(dig);
                    if (foundindex >= 0 && foundindex < firstindex)
                    {
                        firstindex = foundindex;
                        num = digitvalue;
                    }
                    digitvalue++;
                }

                for (var i = 0; i < firstindex; i++)
                {
                    if (line[i] >= '0' && line[i] <= '9')
                    {
                        num = line[i] - '0';
                        break;
                    }
                }

                result += 10 * num;
                Console.Write(num + " ");

                digitvalue = 1;
                foreach (var dig in digits)
                {
                    int foundindex = line.LastIndexOf(dig);
                    if (foundindex >= 0 && foundindex > lastindex)
                    {
                        lastindex = foundindex;
                        num = digitvalue;
                    }
                    digitvalue++;
                }

                for (var i = line.Length - 1; i >= lastindex; i--)
                {
                    if (line[i] >= '0' && line[i] <= '9')
                    {
                        num = line[i] - '0';
                        break;
                    }
                }

                Console.Write(num + " ");
                result += num;

                Console.WriteLine($"{line}");
            }
            Console.WriteLine(result);
        }
    }
}