using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day8
{
    public class Day8 : Day
    {
        private readonly UniqueSignals _uniqueSignals;
        private readonly Signal[] _signals;

        public Day8(bool isTest = false) 
            : base(isTest)
        {
            _uniqueSignals = new UniqueSignals();
            _signals = Input.Select(s => new Signal(_uniqueSignals, s)).ToArray();
        }

        public int Part1()
        {
            int sum = 0;
            var allowed = new[] { 2, 4, 3, 7 };
            foreach (var s in _signals)
            {
                foreach (var g in s.Output.GroupBy(l => l.Length))
                {
                    if (allowed.Contains(g.Key))
                        sum += g.Count();
                }
            }

            return sum;
        }

        public int Part2()
        {
            var byLength = new Dictionary<int, char[][]>();
            foreach (var g in _uniqueSignals.GroupBy(s => s.Length))
                byLength[g.Key] = g.Select(s => s.ToCharArray()).ToArray();

            var decoded = new Dictionary<int, char[]>
            {
                [1] = byLength[2].First(),
                [4] = byLength[4].First(),
                [7] = byLength[3].First(),
                [8] = byLength[7].First()
            };

            var segment = new Dictionary<char, char>(); // reality - wrong
            segment['a'] = decoded[7].Except(decoded[1]).FirstOrDefault();
            char[] bd = decoded[4].Except(decoded[1]).ToArray();
            char[] cf = decoded[1];
            var seg0Or6Or9 = byLength[6].ToList();
            decoded[6] = seg0Or6Or9.First(s => s.Intersect(cf).Count() == 2);
            seg0Or6Or9.Remove(decoded[6]);
            decoded[0] = seg0Or6Or9.First(s => s.Intersect(bd).Count() == 1);
            seg0Or6Or9.Remove(decoded[0]);
            decoded[9] = seg0Or6Or9.First();
            segment['d'] = decoded[8].Except(decoded[0]).First();
            segment['b'] = bd.Except(new[] { segment['d'] }).First();
            segment['e'] = decoded[8].Except(decoded[9]).First();
            var seg2Or3Or5 = byLength[5].ToList();
            decoded[3] = seg2Or3Or5.First(s => s.Intersect(cf).Count() == 2);
            seg2Or3Or5.Remove(decoded[3]);
            decoded[5] = seg2Or3Or5.First(s => s.Contains(segment['b']));
            seg2Or3Or5.Remove(decoded[5]);
            decoded[2] = seg2Or3Or5.First();
            segment['c'] = decoded[0].Except(decoded[6]).First();
            segment['f'] = cf.Except(new[] { segment['c'] }).First();
            segment['g'] = decoded[5].Except(decoded[4]).Except(new char[] { segment['a'] }).First();
            return 0;
        }
    }
}
