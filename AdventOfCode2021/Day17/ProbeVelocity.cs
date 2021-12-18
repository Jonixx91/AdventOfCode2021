using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day17
{
    public class ProbeVelocity
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public ProbeVelocity(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool HitsTarget(Target target)
        {
            var points = new List<Point>()
            {
                new Point(0, 0)
            };
            while (true)
            {
                var next = Next(points.Last());
                if (next.Y < target.Min.Y ||
                    next.X > target.Max.X)
                    break;

                points.Add(next);
            }

            if (points.Last().Y <= target.Max.Y &&
                points.Last().X >= target.Min.X)
                return true;

            return false;
        }

        public Point Next(Point previous)
        {
            var next = new Point(previous.X + X, previous.Y + Y);
            if (X > 0)
                X--;
            else if (X < 0)
                X++;
            Y--;
            return next;
        }
    }
}
