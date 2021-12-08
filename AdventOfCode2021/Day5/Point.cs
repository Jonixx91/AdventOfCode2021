using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day5
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

        public override string ToString() => $"{X},{Y}";

        public static Point Create(string s)
        {
            var coords = s.Split(',');
            return new Point(int.Parse(coords[0]), int.Parse(coords[1]));
        }
    }
}
