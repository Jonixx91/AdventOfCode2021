using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day5
{
    public class Line
    {
        private int[] _dir;

        public Point Start { get; }
        public Point End { get; }
        public bool IsHorizontal { get; }
        public bool IsVertical { get; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
            IsHorizontal = Start.Y == End.Y;
            IsVertical = Start.X == End.X;
            _dir = new[]
            {
                Math.Sign(end.X- start.X),
                Math.Sign(end.Y- start.Y)
            };
        }

        public IEnumerable<Point> GetAllPoints()
        {
            int x = Start.X;
            int y = Start.Y;
            while (true)
            {
                var current = new Point(x, y);
                yield return current;

                if (current.Equals(End))
                    yield break;

                x += _dir[0];
                y += _dir[1];
            }
        }

        public override string ToString() => $"{Start} -> {End}";

        public static Line Create(string s)
        {
            string[] coords = System.Text.RegularExpressions.Regex.Split(s, " -> ");
            return new Line(
                Point.Create(coords[0]),
                Point.Create(coords[1]));
        }
    }
}
