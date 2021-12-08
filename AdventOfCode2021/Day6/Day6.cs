using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day6
{
    public class Day6 : Day
    {
        public Day6(bool isTest = false) 
            : base(isTest)
        {
        }

        private List<LanternFish> Initialize()
        {
            var fishes = new List<LanternFish>();
            foreach (var l in Input)
                fishes.AddRange(l.Split(',').Select(s => new LanternFish(int.Parse(s))));
            return fishes;
        }

        private Dictionary<int, long> InitializeDict()
        {
            var d = new Dictionary<int, long>();
            for (int i = 0; i <= 8; i++)
                d[i] = 0;
            return d;
        }

        public IEnumerable<long> Simulate2(params int[] days)
        {
            var daysToSimulate = new List<int>(days);
            int currentDay = 0;
            var current = InitializeDict();
            foreach (int t in Input.First().Split(',').Select(s => int.Parse(s)))
                current[t]++;
            while (daysToSimulate.Count > 0)
            {
                var newCurrent = InitializeDict();
                for (int i = 1; i <= 8; i++)
                    newCurrent[i - 1] = current[i];
                newCurrent[8] = current[0];
                newCurrent[6] += current[0];
                current = newCurrent;
                currentDay++;

                if (daysToSimulate.Contains(currentDay))
                {
                    daysToSimulate.Remove(currentDay);
                    yield return current.Values.Sum();
                }
            }
        }

        public IEnumerable<int> Simulate(params int[] days)
        {
            var daysToSimulate = new List<int>(days); // If using classes, use one for each timer instead and introduce a counter for covering same fishes.
            int currentDay = 0;
            var fishes = Initialize();
            while (daysToSimulate.Count > 0)
            {
                foreach (var f in fishes.ToArray())
                    f.SimulateOneDay(ref fishes);
                currentDay++;

                if (daysToSimulate.Contains(currentDay))
                {
                    daysToSimulate.Remove(currentDay);
                    yield return fishes.Count;
                }
            }
        }
    }
}
