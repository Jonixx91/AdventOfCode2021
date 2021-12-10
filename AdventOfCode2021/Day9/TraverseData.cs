using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day9
{
    public class TraverseData
    {
        public bool[,] AlreadyTaken { get; }
        public int[,] BasinIndex { get; }

        public TraverseData(int columns, int rows)
        {
            AlreadyTaken = new bool[columns, rows];
            BasinIndex = new int[columns, rows];
        }
    }
}
