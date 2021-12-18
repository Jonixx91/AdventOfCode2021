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
        public int Distance { get; set; } = int.MaxValue;

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

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public bool Equals(Point x, Point y) => x.Equals(y);

        public int GetHashCode(Point obj) => obj.GetHashCode();

        public IEnumerable<Point> GetNeighborgs(Point[,] points)
        {
            var ns = new (int X, int Y)[]
            {
                (X - 1, Y),
                (X + 1, Y),
                (X, Y - 1),
                (X, Y + 1)
            };
            foreach (var t in ns)
            {
                if (t.X >= 0 &&
                    t.X < points.GetLength(0) &&
                    t.Y >= 0 &&
                    t.Y < points.GetLength(1))
                    yield return points[t.X, t.Y];
            }
        }

        public override string ToString() => $"{X},{Y}";
    }
}
