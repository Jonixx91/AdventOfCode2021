using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day12.VisitingStrategy
{
    public abstract class VisitingStrategy
    {
        public abstract bool CanVisit(Cave c, List<Cave> path);
    }
}
