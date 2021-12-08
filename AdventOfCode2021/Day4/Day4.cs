using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
    public class Day4 : Day
    {
        private readonly int[] _numbers;
        private readonly BoardHandler _boards;

        public Day4(bool isTest = false) 
            : base(isTest)
        {
            _numbers = Input[0].Split(',')
                .Select(s => int.Parse(s))
                .ToArray();

            _boards = new BoardHandler(Input.Skip(2).ToArray());
        }

        public int GetFirstWinningBoard() => _boards.Play(_numbers).First();

        public int GetLastWinningBoard() => _boards.Play(_numbers).Last();
    }
}
