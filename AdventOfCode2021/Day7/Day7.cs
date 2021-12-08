using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day7
{
    public class Day7 : Day
    {
        private readonly List<int> _numbersSorted;
        private readonly int _median;
        private readonly int _average;

        public Day7(bool isTest = false) 
            : base(isTest)
        {
            _numbersSorted = Input[0].Split(',').Select(s => int.Parse(s)).ToList();
            _numbersSorted.Sort();
            int medianPos = (int)((_numbersSorted.Count + 1) / 2);
            _median = _numbersSorted[medianPos - 1];
            _average = (int)Math.Round(_numbersSorted.Sum() / (double)_numbersSorted.Count, 0);
        }

        public int Part1()
        {
            return _numbersSorted.Select(n => Math.Abs(_median - n)).Sum();
        }

        private Dictionary<int, int> _factorial = new Dictionary<int, int>();
        private int CalculateFactorial(int diff)
        {
            if (!_factorial.ContainsKey(diff))
            {
                int sum = 0;
                for (int i = 1; i <= diff; i++)
                    sum += i;
                _factorial[diff] = sum;
            }

            return _factorial[diff];
        }

        public int CalculateAlignmentToFactorial(int number)
        {
            return _numbersSorted.Select(n =>  CalculateFactorial(Math.Abs(number - n))).Sum();
        }

        public int Part2()
        {
            var consumption = new List<int>();
            int diff = _average - _median;
            int currentDiff = 0;
            int inc = Math.Sign(diff);
            while (currentDiff <= diff)
            {
                var current = _median + currentDiff;
                consumption.Add(CalculateAlignmentToFactorial(current));
                currentDiff += inc;
            }

            return consumption.Min();
        }
    }
}
