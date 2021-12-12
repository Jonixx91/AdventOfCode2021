using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12.VisitingStrategy
{
    public class SingleSmallCaveTwice : VisitingStrategy
    {
        public override bool CanVisit(Cave c, List<Cave> path)
        {
            if (c.IsSmall)
            {
                if (!path.Contains(c))
                    return true;

                var smallCaves = path.Where(ca => ca.IsSmall);
                return smallCaves.Count().Equals(smallCaves.Distinct().Count());
            }

            return true;
        }
    }
}
