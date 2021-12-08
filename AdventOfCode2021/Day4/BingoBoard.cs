using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    public class BingoBoard
    {
        private readonly List<int>[] _rows;
        private readonly List<int>[] _columns;
        private readonly Dictionary<int, (int Row, int Column)> _numberPosition;

        public int[] OriginalNumbers { get; }

        public BingoBoard(string[] lines)
        {
            _rows = new List<int>[5];
            _columns = new List<int>[5];
            _numberPosition = new Dictionary<int, (int Row, int Column)>();
            for (int i = 0; i < 5; i++)
            {
                _rows[i] = new List<int>();
                _columns[i] = new List<int>();
            }
                
            for (int r = 0; r < 5; r++)
            {
                var numbersInRow = new int[5];
                var matches = Regex.Matches(lines[r], @"\d+");
                for (int i = 0; i < 5; i++)
                    numbersInRow[i] = int.Parse(matches[i].Value);

                for (int c = 0; c < 5; c++)
                {
                    int number = numbersInRow[c];
                    _rows[r].Add(number);
                    _columns[c].Add(number);
                    _numberPosition.Add(number, (r, c));
                }
            }
            OriginalNumbers = _numberPosition.Keys.ToArray();
        }

        public bool IsBingo(int number)
        {
            var position = _numberPosition[number];
            _rows[position.Row].Remove(number);
            _columns[position.Column].Remove(number);
            _numberPosition.Remove(number);

            return _rows[position.Row].Count == 0 ||
                _columns[position.Column].Count == 0;
        }

        public int[] GetUnsuedNumbers() => _numberPosition.Keys.ToArray();
    }
}
