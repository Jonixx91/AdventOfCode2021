using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12
{
    public class Day12 : Day
    {
        public Day12(bool isTest = false) 
            : base(isTest)
        {
        }

        private Cave Read(IEnumerable<string> lines)
        {
            var caves = new Dictionary<string, Cave>();
            foreach (var l in lines)
            {
                var cavesInLine = l.Split('-');
                foreach (var c in cavesInLine)
                {
                    if (!caves.ContainsKey(c))
                        caves.Add(c, new Cave(c));
                }

                caves[cavesInLine[0]].Connect(caves[cavesInLine[1]]);
            }

            return caves["start"];
        }

        public int Run(IEnumerable<string> lines, VisitingStrategy.VisitingStrategy strategy)
        {
            var paths = new List<Cave[]>();
            var start = Read(lines);
            start.Visit(ref paths, strategy, new List<Cave>());
            return paths.Count;
        }

        public int Part1(IEnumerable<string> lines) => Run(lines, new VisitingStrategy.SmallCavesOnce());
        public int Part1() => Part1(Input);

        public int Part2(IEnumerable<string> lines) => Run(lines, new VisitingStrategy.SingleSmallCaveTwice());
        public int Part2() => Part2(Input);
    }
}
