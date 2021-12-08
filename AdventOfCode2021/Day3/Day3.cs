using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day3
{
    public class Day3 : Day
    {
        private readonly int _wordLength;

        public Day3(bool isTest = false) 
            : base(isTest)
        {
            _wordLength = Input[0].Length;
        }

        public int CalculatePowerConsumption()
        {
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < _wordLength; i++)
            {
                var count = new Dictionary<char, int>
                {
                    ['0'] = 0,
                    ['1'] = 0
                };

                foreach (string l in Input)
                    count[l[i]]++;

                var ordered = count.OrderBy(kv => kv.Value)
                    .Select(kv => kv.Key)
                    .ToArray();
                gamma += ordered[1];
                epsilon += ordered[0];
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        private int Calculate(Func<Dictionary<char, List<string>>, List<string>> take)
        {
            var current = Input.ToList();
            for (int i = 0; i < _wordLength; i++)
            {
                var count = new Dictionary<char, List<string>>
                {
                    ['0'] = new List<string>(),
                    ['1'] = new List<string>()
                };
                foreach (var l in current)
                    count[l[i]].Add(l);
                current = take(count);

                if (current.Count == 1)
                    return Convert.ToInt32(current[0], 2);
            }

            throw new ArgumentOutOfRangeException();
        }

        public int CalculateLifeSupportRating()
        {
            var oxygenRating = Calculate((d) =>
            {
                if (d['1'].Count >= d['0'].Count)
                    return d['1'];
                return d['0'];
            });

            var co2ScrubberingRate = Calculate((d) =>
            {
                if (d['0'].Count <= d['1'].Count)
                    return d['0'];
                return d['1'];
            });

            return oxygenRating * co2ScrubberingRate;
        }
    }
}
