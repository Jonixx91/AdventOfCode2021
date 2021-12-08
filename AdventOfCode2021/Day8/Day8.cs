using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day8
{
    public class Day8 : Day
    {
        private readonly Display[] _displays;

        public Day8(bool isTest = false) 
            : base(isTest)
        {
            _displays = Input.Select(s => new Display(s)).ToArray();
        }

        public int Part1()
        {
            int sum = 0;
            var allowed = new[] { 2, 4, 3, 7 };
            foreach (var s in _displays)
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
            return _displays.Sum(d => d.CalculateOutput());
        }
    }
}
