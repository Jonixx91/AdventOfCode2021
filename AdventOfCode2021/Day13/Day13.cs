using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2021.Day13.Folding;

namespace AdventOfCode2021.Day13
{
    public class Day13 : Day
    {
        private readonly List<Point> _points;
        private readonly List<FoldOperation> _folds;

        public Day13(bool isTest = false) 
            : base(isTest)
        {
            _points = new List<Point>();
            _folds = new List<FoldOperation>();
            bool readPoints = true;
            foreach (var l in Input)
            {
                if (l.Length == 0)
                {
                    readPoints = false;
                    continue;
                }

                if (readPoints)
                    _points.Add(Point.Create(l));
                else
                    _folds.Add(FoldOperation.Create(l));
            }
        }

        private void Apply(FoldOperation operation)
        {
            foreach (var p in _points)
                operation.Fold(p);
        }

        public int Part1()
        {
            Apply(_folds.First());

            return _points.Distinct().Count();
        }

        public int Part2()
        {
            foreach (var f in _folds)
                Apply(f);

            return _points.Distinct().Count();
        }

        public void Visualize()
        {
            var distinctOrdered = _points.Distinct()
                .OrderBy(p => p.X)
                .ThenBy(p => p.Y)
                .ToArray();
            var maxX = distinctOrdered.Select(p => p.X).Max() + 1;
            var maxY = distinctOrdered.Select(p => p.Y).Max() + 1;
            var hasPoint = new bool[maxX, maxY];
            foreach (var p in distinctOrdered)
                hasPoint[p.X, p.Y] = true;

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                    Console.Write(hasPoint[x, y] ? "#" : ".");

                Console.WriteLine();
            }
                    
        }
    }
}
