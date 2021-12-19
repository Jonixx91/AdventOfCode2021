using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode2021.Day13.Folding;

namespace AdventOfCode2021.Day15
{
    public class Day15 : Day
    {
        private int[,] _graph;
        private int _maxX;
        private int _maxY;

        public Day15(bool isTest = false) 
            : base(isTest)
        {
            _maxX = Input[0].Length;
            _maxY = Input.Count;
            _graph = new int[_maxX, _maxY];
            for (int y = 0; y < _maxY; y++)
                for (int x = 0; x < _maxX; x++)
                    _graph[x, y] = int.Parse(new string(new[] { Input[y][x] }));
        }

        private class DistanceComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return x.Distance.CompareTo(y.Distance);
            }
        }

        private int RunDijkstra()
        {
            var points = new Point[_maxX, _maxY];
            var toVisit = new VisitDictionary();
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    var p = new Point(x, y);
                    points[x, y] = p;
                    toVisit.Add(p);
                }
            }
            

            points[0, 0].Distance = 0;
            while (toVisit.HasValues())
            {
                var closest = toVisit.GetNextValue();
                foreach (var n in closest.GetNeighborgs(points))
                {
                    var newDist = closest.Distance + _graph[n.X, n.Y];
                    if (newDist < n.Distance)
                        toVisit.UpdateDistance(n, newDist);
                }
            }

            return points[_maxX - 1, _maxY - 1].Distance;
        }

        public int Part1() => RunDijkstra();

        private int ResetIfOver9(int i)
        {
            if (i > 9)
                return i - 9;
            return i;
        }

        private void EnlargeMap()
        {
            var newMap = new int[_maxY * 5, _maxY * 5];
            for (int y = 0; y < _maxY; y++)
                for (int x = 0; x < _maxX; x++)
                    for (int i = 0; i <= 4; i++)
                        newMap[x + i * _maxX, y] = ResetIfOver9(_graph[x, y] + i);
            _maxX *= 5;

            for (int y = 0; y < _maxY; y++)
                for (int x = 0; x < _maxX; x++)
                    for (int i = 0; i <= 4; i++)
                        newMap[x, y + i * _maxY] = ResetIfOver9(newMap[x, y] + i);
            _graph = newMap;
            _maxY *= 5;
        }

        public int Part2()
        {
            EnlargeMap();
            return RunDijkstra();
        }
    }
}
