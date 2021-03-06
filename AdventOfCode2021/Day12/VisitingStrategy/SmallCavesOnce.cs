using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12.VisitingStrategy
{
    public class SmallCavesOnce : VisitingStrategy
    {
        public override bool CanVisit(Cave c, List<Cave> path)
        {
            if (c.IsSmall && path.Contains(c))
                return false;
            return true;
        }
    }
}
