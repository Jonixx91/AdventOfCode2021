using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day17
{
    public class Target
    {
        public Point Min { get; }
        public Point Max { get; }

        public Target(Point min, Point max)
        {
            Min = min;
            Max = max;
        }
    }
}
