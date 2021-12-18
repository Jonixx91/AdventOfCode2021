using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day17
{
    public class Day17 : Day
    {
        public Target TestTarget { get; }
        public Target RealTarget { get; }

        public Day17(bool isTest = false) 
            : base(isTest)
        {
            TestTarget = new Target(new Point(20, -10), new Point(30, -5));
            RealTarget = new Target(new Point(156, -110), new Point(202, -69));
        }

        public int FindMaxY(Target t)
        {
            for (int i = Math.Abs(t.Min.Y); i > 1; i--)
            {
                var vel = new ProbeVelocity(0, i);
                var points = new List<Point>()
                {
                    new Point(0,0)
                };
                while (true)
                {
                    var next = vel.Next(points.Last());
                    if (next.Y < t.Min.Y)
                        break;

                    points.Add(next);
                }

                if (points.Last().Y < t.Max.Y)
                    return points.Select(p => p.Y).Max();
            }

            return 0;
        }

        public int FindCombinations(Target t)
        {
            int combinations = 0;
            for (int y = t.Min.Y; y <= Math.Abs(t.Min.Y); y++)
            {
                for (int x = 1; x <= Math.Abs(t.Max.X); x++)
                    if (new ProbeVelocity(x, y).HitsTarget(t))
                        combinations++;
                        
            }

            return combinations;
        }

        public int Part1() => FindMaxY(RealTarget);
        public int Part2() => FindCombinations(RealTarget);
    }
}
