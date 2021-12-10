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
        private readonly int[,] _heights; // row - column

        public Day9(bool isTest = false) 
            : base(isTest)
        {
            _columns = Input.First().Trim().Length;
            _rows = Input.Count;
            _heights = new int[_rows,_columns];
            for (int r = 0; r < _rows; r++)
            {
                var row = new int[_columns];
                for (int c = 0; c < _columns; c++)
                    _heights[r, c] = int.Parse(new string(new[] { Input[r][c] }));
            }
        }

        private bool IsMinimum(int row, int column)
        {
            var values = new List<int?>();
            foreach (int i in new[] { -1, 1 })
            {
                values.Add(GetValue(row, column + i));
                values.Add(GetValue(row + i, column));
            }

            return _heights[row, column] < values.Where(v => v.HasValue).Select(v => v.Value).Min();
        }

        private bool IsValidPosition(int row, int column)
        {
            return column >= 0 &&
                   column < _columns &&
                   row >= 0 &&
                   row < _rows;
        }

        private int? GetValue(int row, int column)
        {
            if (IsValidPosition(row, column))
                return _heights[row, column];
            return null;
        }

        public IEnumerable<int> FindMinimums()
        {
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    if (IsMinimum(r, c))
                        yield return _heights[r, c];
                }
            }
        }

        public int Part1() => FindMinimums().Select(m => m + 1).Sum();

        public int Part2()
        {
            var basins = new List<int>();
            bool[,] visited = new bool[_rows, _columns];

            int FindBasinForPoint(int r, int c, int? previous)
            {
                int sum = 0;
                if (!IsValidPosition(r, c) ||
                    visited[r, c])
                    return 0;

                int value = _heights[r, c];
                if (previous.HasValue)
                {
                    if (Math.Abs(value - previous.Value) > 1 ||
                        value == 9)
                        return 0;
                }

                sum++;
                visited[r, c] = true;

                sum += FindBasinForPoint(r - 1, c, value);
                sum += FindBasinForPoint(r + 1, c, value);
                sum += FindBasinForPoint(r, c - 1, value);
                sum += FindBasinForPoint(r, c + 1, value);

                return sum;
            }

            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _columns; c++)
                {
                    if (!visited[r, c] && _heights[r, c] != 9)
                        basins.Add(FindBasinForPoint(r, c, null));
                }
            }

            var product = 1;
            var largestThree = basins.OrderByDescending(b => b).Take(3).ToArray();
            foreach (var l in largestThree)
                product *= l;
            return product;
        }
    }
}
