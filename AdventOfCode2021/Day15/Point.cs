using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day15
{
    public class Point : IEqualityComparer<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode() => ToString().GetHashCode();

        public bool Equals(Point x, Point y) => x.Equals(y);

        public int GetHashCode(Point obj) => obj.GetHashCode();

        private bool IsValid(int maxX, int maxY)
        {
            return X >= 0 &&
                   X < maxX &&
                   Y >= 0 &&
                   Y < maxY;

        }

        public IEnumerable<Point> GetNeighborgs(int maxX, int maxY)
        {
            var ns = new Point[]
            {
                new Point(X - 1, Y),
                new Point(X + 1, Y),
                new Point(X, Y - 1),
                new Point(X, Y + 1)
            };
            foreach (var n in ns)
            {
                if (n.IsValid(maxX, maxY))
                    yield return n;
            }
        }

        public override string ToString() => $"{X},{Y}";
    }
}
