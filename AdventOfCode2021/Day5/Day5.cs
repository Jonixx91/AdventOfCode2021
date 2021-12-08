using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day5
{
    public class Day5 : Day
    {
        private readonly Line[] _lines;

        public Day5(bool isTest = false) 
            : base(isTest)
        {
            _lines = Input.Select(s => Line.Create(s)).ToArray();
        }

        private int CalculateOverlaps(IEnumerable<Line> lines)
        {
            var dict = new Dictionary<Point, int>();
            foreach (var l in lines)
            {
                foreach (var p in l.GetAllPoints())
                {
                    if (!dict.ContainsKey(p))
                        dict.Add(p, 0);
                    dict[p]++;
                }
            }

            return dict.Values.Count(v => v > 1);
        }

        public int Part1() => CalculateOverlaps(_lines.Where(l => l.IsHorizontal || l.IsVertical));
        public int Part2() => CalculateOverlaps(_lines);
    }
}
