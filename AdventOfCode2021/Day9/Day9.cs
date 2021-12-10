using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day9
{
    public class Day9 : Day
    {
        private readonly int _columns;
        private readonly int _rows;
        private readonly int[,] _heights; // x,y

        public Day9(bool isTest = false) 
            : base(isTest)
        {
            _columns = Input.First().Trim().Length;
            _rows = Input.Count;
            _heights = new int[_columns, _rows];
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                    _heights[x, y] = int.Parse(new string(new[] { Input[y][x] }));
            }
        }

        private bool IsMinimum(int x, int y)
        {
            var values = new List<int?>();
            foreach (int i in new[] { -1, 1 })
            {
                values.Add(GetValue(x, y + i));
                values.Add(GetValue(x + i, y));
            }

            return _heights[x, y] < values.Where(v => v.HasValue).Select(v => v.Value).Min();
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 &&
                   x < _columns &&
                   y >= 0 &&
                   y < _rows;
        }

        private int? GetValue(int x, int y)
        {
            if (IsValidPosition(x, y))
                return _heights[x, y];
            return null;
        }

        public IEnumerable<Minimum> FindMinimums()
        {
            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    if (IsMinimum(x, y))
                        yield return new Minimum(x, y, _heights[x, y]);
                }
            }
        }

        public int Part1() => FindMinimums().Select(m => m.Height + 1).Sum();

        private int FindBasinSize(TraverseData data, int index, int x, int y, int? previousHeight)
        {
            if (!IsValidPosition(x, y) ||
                data.AlreadyTaken[x, y] || 
                _heights[x, y] == 9)
                return 0;

            int height = _heights[x, y];
            if (previousHeight.HasValue &&
                height < previousHeight.Value)
                return 0;

            int sum = 1;
            data.AlreadyTaken[x, y] = true;
            data.BasinIndex[x, y] = index;
            sum += FindBasinSize(data, index, x - 1, y, height);
            sum += FindBasinSize(data, index, x + 1, y, height);
            sum += FindBasinSize(data, index, x, y - 1, height);
            sum += FindBasinSize(data, index, x, y + 1, height);
            return sum;
        }

        public void Part2(out TraverseData data, out List<int> basins)
        {
            basins = new List<int>();
            data = new TraverseData(_columns, _rows);
            foreach (var m in FindMinimums())
                basins.Add(FindBasinSize(data, basins.Count + 1, m.X, m.Y, null));
        }

        public long Part2()
        {
            Part2(out var data, out var basins);
            var largestThree = basins.OrderByDescending(b => b).Take(3).ToArray();
            long product = 1;
            foreach (var l in largestThree)
                product *= l;
            return product;
        }

        public void VisualizePart2()
        {
            Part2(out var data, out var basins);

            var width = Input[0].Length;
            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int skip = 3;
                    var color = data.AlreadyTaken[x, y]
                        ? data.BasinIndex[x, y] % (16 - skip)
                        : skip - 1;
                    Console.ForegroundColor = (ConsoleColor)color;
                    Console.Write(Input[y][x]);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
