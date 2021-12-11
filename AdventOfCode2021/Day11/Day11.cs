using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day11
{
    public class Day11 : Day
    {
        private readonly int[,] _values;

        public Day11(bool isTest = false) 
            : base(isTest)
        {
            _values = new int[10,10];
            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 10; x++)
                    _values[x, y] = int.Parse(new string(new[] { Input[y][x] }));
        }

        private int CountFlashes(ref bool[,] flashedDuringStep, int x, int y)
        {
            int flashes = 0;
            if (_values[x, y] > 9 &&
                !flashedDuringStep[x, y])
            {
                flashedDuringStep[x, y] = true;
                flashes++;

                var adj = new List<(int X, int Y)>();
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0)
                            continue;

                        var newX = x + dx;
                        var newY = y + dy;
                        if (newX >= 0 &&
                            newY >= 0 &&
                            newX < 10 &&
                            newY < 10)
                        {
                            adj.Add((newX, newY));
                        }
                            
                    }
                }

                foreach (var t in adj)
                    _values[t.X, t.Y]++;
                foreach (var t in adj)
                    flashes += CountFlashes(ref flashedDuringStep, t.X, t.Y);
            }

            return flashes;
        }

        private int SimulateStep()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    _values[x, y]++;

            int flashesDuringCurrentStep = 0;
            bool[,] flashedDuringStep = new bool[10, 10];
            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 10; x++)
                    flashesDuringCurrentStep += CountFlashes(ref flashedDuringStep, x, y);
             
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (_values[x, y] > 9)
                        _values[x, y] = 0;
                }
            }

            return flashesDuringCurrentStep;
        }

        public int Part1()
        {
            int flashes = 0;
            for (int i = 0; i < 100; i++)
                flashes += SimulateStep();
            return flashes;
        }

        public int Part2()
        {
            int step = 1;
            while (true)
            {
                int flashes = SimulateStep();
                if (flashes == 100)
                    return step;

                step++;
            }
        }
    }
}
