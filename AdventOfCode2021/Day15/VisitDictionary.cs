using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day15
{
    public class VisitDictionary : SortedDictionary<int, HashSet<Point>>
    {
        public void Add(int distance, Point point)
        {
            if (!ContainsKey(distance))
                Add(distance, new HashSet<Point>());
            this[distance].Add(point);
        }

        public void Add(Point p)
        {
            Add(p.Distance, p);
        }

        public void UpdateDistance(Point p, int newDistance)
        {
            bool updated = false;
            if (TryGetValue(p.Distance, out var value))
            {
                if (value.Contains(p))
                {
                    value.Remove(p);
                    if (value.Count == 0)
                        Remove(p.Distance);

                    p.Distance = newDistance;
                    Add(p);
                    updated = true;
                }
            }

            if (!updated)
                p.Distance = newDistance;
        }

        public bool HasValues() => Keys.Count > 0;

        public Point GetNextValue()
        {
            var dist = Keys.First();
            var list = this[dist];
            var next = list.First();
            list.Remove(next);
            if (list.Count == 0)
                Remove(dist);
            return next;
        }
    }
}
