using System.Collections.Generic;

namespace AoC
{
    struct Hand
    {
        public string hand;
        public int value;
        public int bid;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> cardval = new() {
                { 'A', 15 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 }, { '9', 9 }, { '8', 8 },
                { '7', 7 }, { '6', 6 }, { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 }
            };

            List<Hand> hands = new();

            var sr = new StreamReader(@"..\..\input.txt");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(' ');
                var hand = line[0];
                var bid = int.Parse(line[1]);

                Dictionary<char, int> dict = new();
                for (int i = 0; i < 5; i++)
                {
                    var cv = hand[i];
                    if (!dict.TryAdd(cv, 1)) dict[cv]++;
                }

                int hv = 0;
                foreach (var v in dict.Values) if (v > hv) hv = v;

                int kind = 6 - dict.Count + hv;

                int value =
                      0x100000 * kind
                    + 0x010000 * cardval[hand[0]]
                    + 0x001000 * cardval[hand[1]]
                    + 0x000100 * cardval[hand[2]]
                    + 0x000010 * cardval[hand[3]]
                    + 0x000001 * cardval[hand[4]];

                hands.Add(new Hand { hand = hand, value = value, bid = bid });
            }

            hands.Sort((a, b) => a.value.CompareTo(b.value));

            long result = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                Console.WriteLine($"{i + 1:d4} {hands[i].hand} {hands[i].value:x} {hands[i].bid}");
                result += hands[i].bid * (i + 1);
            }

            Console.WriteLine(result);
        }
    }
}