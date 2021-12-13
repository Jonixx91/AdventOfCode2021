using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day13
{
    public class Point : IEqualityComparer<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

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

        public void Set(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"{X},{Y}";

        public static Point Create(string s)
        {
            var coords = s.Split(',');
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }
    }
}
